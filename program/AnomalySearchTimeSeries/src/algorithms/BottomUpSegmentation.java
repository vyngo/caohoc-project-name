/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package algorithms;

import common.Utils;
import entity.NSubsequence;
import entity.NTimeSeries;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Khanh Vy
 */
public class BottomUpSegmentation {

    public static List<NSubsequence> segmentation(NTimeSeries series, double e1) {
        List<NSubsequence> ret = new ArrayList<NSubsequence>();
        List<Double> mergeCost = new ArrayList<Double>();
        int length = series.getNumberOfDataPoint();
        int i;
        List<Double> data = series.getData();
        Utils.println("Init subsequence with length 2");
        for (i = 0; i < length - 1; i += 2) {
            ret.add(new NSubsequence(i, i + 1));
        }
        int sizeOfSub = ret.size();
        Utils.println("Calculate merge cost list");
        for (i = 0; i < sizeOfSub - 1; i++) {
            NSubsequence temp = new NSubsequence(ret.get(i).getStart(), ret.get(i + 1).getEnd());
            mergeCost.add(calculateError(data, temp));
        }
        while (true) {
            MinMergCost cost = min(mergeCost);
            if(cost.min > e1){
                break;
            }
            Utils.println("min cost: " + cost.min + ", min index: " + cost.index);
            Utils.println("Size subsequence: " + ret.size() + ", Size merge cost: " + mergeCost.size());
            NSubsequence m = ret.get(cost.index);
            NSubsequence mPlus1 = ret.get(cost.index + 1);
            m.setEnd(mPlus1.getEnd());
            if(cost.index + 1 < ret.size()){
                ret.remove(cost.index + 1);
            }
            //update merger_code
            if(cost.index + 1 < mergeCost.size() && cost.index < ret.size() - 1){
                mergeCost.remove(cost.index + 1);
                Double costi = calculateError(data, m);
                mergeCost.set(cost.index, costi);
            }else{
                mergeCost.set(cost.index, Double.MAX_VALUE);
            }
            if (cost.index - 1 >= 0) {
                NSubsequence mMinus1 = ret.get(cost.index - 1);
                NSubsequence temp = new NSubsequence(mMinus1.getStart(), m.getEnd());
                mergeCost.set(cost.index - 1, calculateError(data, temp));
            }
        }
        return ret;
    }

    private static double calculateError(List<Double> data, NSubsequence seq) {
        int s = seq.getStart();
        int e = seq.getEnd();
        int l = seq.getLength();

        List<Double> subList = data.subList(s, e + 1);
        double[] y = Utils.listToArray(subList);
        double[] x = new double[l];
        for (int i = 0; i < l; i++) {
            x[i] = s + i;
        }
        double[] reg = LinearRegression.regress(x, y);
        return reg[2];
    }
    
    private static MinMergCost min(List<Double> data) {
        double min = Double.MAX_VALUE;
        int index = 0;
        int size = data.size();
        for (int i = 0; i < size; i++) {
            if (min > data.get(i)) {
                min = data.get(i);
                index = i;
            }
        }
        return new MinMergCost(index, min);
    }

    private static class MinMergCost {

        public int index;
        public double min;

        public MinMergCost(int index, double min) {
            this.index = index;
            this.min = min;
        }
    }
}
