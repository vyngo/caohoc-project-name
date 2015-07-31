/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package algorithms;

import common.Utils;
import entity.NSubsequence;
import entity.NTimeSeries;
import java.io.File;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 *
 * @author Khanh Vy
 */
public class VarLength {

    private List<NSubsequence> anomalyPatterns = null;
    private NTimeSeries series = null;
    double e1;
    double e2;

    public VarLength() {
        series = new NTimeSeries();
        anomalyPatterns = new ArrayList<NSubsequence>();
    }

    public void initData(String pathFile) {
        readDataFromFile(pathFile);
    }
    
    public NTimeSeries getTimeSeries(){
        return series;
    }

    private List<NSubsequence> segmentation() {
        List<NSubsequence> ret = new ArrayList<NSubsequence>();
        boolean halt = false;
        int start = 0;
        do{
            NSubsequence sequence = getASegment(start);
            ret.add(sequence);
            int end = sequence.getEnd();
            if(end == (series.getNumberOfDataPoint() - 1)){
                halt = true;
            }else{
                start = getNextStartIndex(sequence);
            }
        }while(!halt);
        return ret;
    }
    
    private int getNextStartIndex(NSubsequence se){
       int start = se.getStart();
       int end = se.getEnd();
       int i = 1;
       List<Double> imageSubSequence = series.getData().subList(start, end+1);
       List<Double> candidateSequence = series.getData().subList(start + i, end + i + 1);
       while(DistanceCal.distance(Utils.listToArray(imageSubSequence), Utils.listToArray(candidateSequence)) <= e2
               && i < (end - start)){
           i++;
       }
       return end + i;
    }

    private NSubsequence getASegment(int start) {
        NSubsequence ret = null;
        boolean halt = false;
        int l = 4;// initial length
        int s = start;
        do {
            int e = s + l - 1;
            if(e >= series.getNumberOfDataPoint() - 1){
                ret = new NSubsequence(start, series.getNumberOfDataPoint() - 1);
                break;
            }
            List<Double> subList = series.getData().subList(s, e + 1);
            double[] y = Utils.listToArray(subList);
            double[] x = new double[l];
            for (int i = 0; i < l; i++) {
                x[i] = s + i;
            }
            double[] reg = QuadraticRegression.regress(x, y);
            if (reg[3] >= e1) {
                halt = true;
                ret = new NSubsequence(start, e-1);
            } else {
                l += 1;
            }
        } while (!halt);
        return ret;
    }

    private void readDataFromFile(String filePath) {
        Scanner scanner = null;
        try {
            // Location of file to read
            File file = new File("data.txt");
            scanner = new Scanner(file);
            int i = 0;
            while (scanner.hasNextLine()) {
                i++;
                String line = scanner.nextLine();
                if (i == 1) {
                    e1 = Double.parseDouble(line);
                } else if (i == 2) {
                    e2 = Double.parseDouble(line);
                } else {
                    series.addData(Double.parseDouble(line));
                }
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
    
    public static void main(String[] args) {
         String fileData = "data.txt";
         VarLength v = new VarLength();
         v.initData(fileData);
         List<NSubsequence> ret = v.segmentation();
         for(NSubsequence s : ret){
             System.out.println(s.getStart() + " - " + s.getEnd());
         }
    }
}
