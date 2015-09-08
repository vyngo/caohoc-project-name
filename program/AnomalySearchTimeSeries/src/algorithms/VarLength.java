/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package algorithms;

import chart.JChart;
import common.Utils;
import entity.NSubsequence;
import entity.NTimeSeries;
import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Scanner;

/**
 *
 * @author Khanh Vy
 */
public class VarLength {

    private List<NSubsequence> anomalyPatterns = null;
    private NTimeSeries series = null;
    private double e1;
    private double e2;
    private int k;
    private double threshold;

    public VarLength(double e1, double e2) {
        series = new NTimeSeries();
        anomalyPatterns = new ArrayList<NSubsequence>();
        this.e1 = e1;
        this.e2 = e2;
        this.k = 0;
        this.threshold = 3.0;
    }
    
    public VarLength(double e1, double e2, int k) {
        series = new NTimeSeries();
        anomalyPatterns = new ArrayList<NSubsequence>();
        this.e1 = e1;
        this.e2 = e2;
        this.k = k;
        this.threshold = 3.0;
    }
    
    public VarLength(double e1, double e2, int k, double threshold) {
        series = new NTimeSeries();
        anomalyPatterns = new ArrayList<NSubsequence>();
        this.e1 = e1;
        this.e2 = e2;
        this.k = k;
        this.threshold = threshold;
    }

    public void initData(String pathFile) {
        readDataFromFile(pathFile);
    }

    public NTimeSeries getTimeSeries() {
        return series;
    }
    
    public void run(){
        List<NSubsequence> candiates = segmentation();
        anomalyPatterns.addAll(anomalyFind(candiates));
        for(NSubsequence n : anomalyPatterns){
           Utils.printSegment(n);
        }
        JChart.drawChart(series, anomalyPatterns);
    }

    private List<NSubsequence> segmentation() {
        return QuaradicSegmentation.segmentation(series, e1, e2);
    }

    private List<NSubsequence> anomalyFind(List<NSubsequence> candidates) {
        List<NSubsequence> ret = new ArrayList<NSubsequence>();
        if (candidates != null && !candidates.isEmpty()) {
            int lmax = Integer.MIN_VALUE;
            int lmin = Integer.MAX_VALUE;
            for (NSubsequence seq : candidates) {
                int length = seq.getLength();
                if (length > lmax) {
                    lmax = length;
                }
                if (length < lmin) {
                    lmin = length;
                }
            }
            int size = candidates.size();
            double[][] distanceMatrix = distanceMatrixCal(candidates, lmin, lmax);
            if(k <= 0){
                k = Double.valueOf(Math.ceil(0.05 * size)).intValue();
            }
            List<Double> kDis = new ArrayList<Double>();
            for(int i = 0; i < size; i++){
                double tmp = calKDistance(i, k, distanceMatrix);
                kDis.add(tmp);
            }
            double median = Utils.median(kDis);
            List<Double> anomalyFactors = calAnomalyFactor(kDis, median);
            for(int i = 0; i < size; i++){
                if(anomalyFactors.get(i) > threshold){
                    ret.add(candidates.get(i));
                }
            }
        }
        return mergeAnomalyPattern(ret);
    }
    
    private List<NSubsequence> mergeAnomalyPattern(List<NSubsequence> candidates){
        int size = candidates.size();
        List<NSubsequence> ret = new ArrayList<NSubsequence>();
        List<Integer> banIndex = new ArrayList<Integer>();
        for(int i = 0; i < size; i++){
            if(banIndex.contains(i)){
                continue;
            }
            NSubsequence n = new NSubsequence(candidates.get(i).getStart(), candidates.get(i).getEnd());
            for(int j = i+1; j < size; j++){
                if(!banIndex.contains(j)){
                   NSubsequence tmp = candidates.get(j);
                   if((tmp.getStart() >= n.getStart() && tmp.getStart() <= n.getEnd())
                           || (tmp.getStart() == n.getEnd() + 1)){
                       n.setEnd(tmp.getEnd());
                       banIndex.add(j);
                   }
                }
            }
            ret.add(n);
        }
        return ret;
    }
    
    private List<Double> calAnomalyFactor(List<Double> kDis, double median){
       List<Double> ret = new ArrayList<Double>();
       int size = kDis.size();
       for(int i = 0; i < size; i++){
           ret.add(kDis.get(i) / median);
       }
       return ret;
    }
    
    private double calKDistance(int pattern, int k, double[][] matrix){
        int size = matrix.length;
        List<Double> tmp = new ArrayList<Double>();
        for(int i = 0; i < size; i++){
            if(pattern != i){
                tmp.add(matrix[pattern][i]);
            }
        }
        Collections.sort(tmp);
        return tmp.get(k-1);
    }

    private double[][] distanceMatrixCal(List<NSubsequence> candidates, int lmin, int lmax) {
        int length = candidates.size();
        double[][] ret = new double[length][length];
        for (int i = 0; i < length; i++) {
            for (int j = 0; j < length; j++) {
                if(i == j){
                    ret[i][j] = 0.0;
                    continue;
                }
                ret[i][j] = distance(candidates.get(i), candidates.get(j), lmin, lmax);
            }
        }
        return ret;
    }

    private double distance(NSubsequence s1, NSubsequence s2, int lmin, int lmax) {
        int sj = s2.getStart();
        int si = s1.getStart();
        int ei = s1.getEnd();
        double ret = Double.MAX_VALUE;
        double[] a = getSegment(si, ei);
        int limit = series.getData().size();
        for (int l = lmin; l <= lmax; l++) {
            if (sj + l <= limit) {
                double[] b = getSegment(sj, sj + l - 1);
                double cal = DistanceCal.distance(a, b);
                if (cal < ret) {
                    ret = cal;
                }
            }else{
                break;
            }
        }
        return ret;
    }

    private double[] getSegment(int start, int end) {
        return Utils.listToArray(series.getData().subList(start, end + 1));
    }

    private void readDataFromFile(String filePath) {
        Scanner scanner = null;
        try {
            // Location of file to read
            File file = new File(filePath);
            scanner = new Scanner(file);
            int i = 0;
            while (scanner.hasNextLine()) {
                i++;
                String draw = scanner.nextLine();
//                String[] aline = draw.split(" ");
                String line = draw.trim();
                series.addData(Double.parseDouble(line));
            }
            scanner.close();
        } catch (Exception ex) {
            ex.printStackTrace(System.out);
        } finally {
            if (scanner != null) {
                scanner.close();
            }
        }
    }
//    public static void main(String[] args) {
//        String fileData = "data.txt";
//        VarLength v = new VarLength();
//        v.initData(fileData);
//        List<NSubsequence> ret = v.segmentation();
//        for (NSubsequence s : ret) {
//            System.out.println(s.getStart() + " - " + s.getEnd());
//        }
//    }
}
