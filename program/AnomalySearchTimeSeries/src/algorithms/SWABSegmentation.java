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
public class SWABSegmentation {

    public static List<NSubsequence> segmentation(NTimeSeries series, double e1, int w) {
        List<NSubsequence> ret = new ArrayList<NSubsequence>();
        int lower_bound = w / 2;
        int upper_bound = 2 * w;
        List<Double> data = series.getData();
        int size = data.size();
        Buffer buffer = new Buffer(0, w - 1);
        while (buffer.end < size) {
            List<Double> temp = new ArrayList<Double>();
            for (int i = buffer.begin; i <= buffer.end; i++) {
                temp.add(data.get(i));
            }
            List<NSubsequence> subTemp = segmentationForBuffer(buffer.begin, temp, e1);
            NSubsequence asub = getFirstSubsequence(subTemp);
            asub.setStart(buffer.begin + asub.getStart());
            asub.setEnd(buffer.begin + asub.getEnd());
            ret.add(asub);
            buffer.begin = asub.getEnd() + 1;

            int nexEnd = bestLine(e1, buffer.end, data);
            if (nexEnd >= size - 1) {// segment leave out
                List<Double> temp1 = new ArrayList<Double>();
                for (int i = buffer.begin; i <= size - 1; i++) {
                    temp1.add(data.get(i));
                }
                List<NSubsequence> remain = segmentationForBuffer(buffer.begin, temp1, e1);
                for(NSubsequence s : remain){
                    NSubsequence a = new NSubsequence(buffer.begin + s.getStart(), buffer.begin + s.getEnd());
                    ret.add(a);
                }
                buffer.end = size;// halt
            } else {
                int newsize = nexEnd - buffer.begin + 1;
                if (newsize < lower_bound) {
                    nexEnd = lower_bound + buffer.begin - 1;
                } else if (newsize > upper_bound) {
                    nexEnd = upper_bound + buffer.begin - 1;
                }
                buffer.end = nexEnd;
            }

            Utils.println("==========BUFFER==========");
            Utils.println("buffer: " + buffer.begin + " - " + buffer.end);
        }
        return ret;
    }

    private static NSubsequence getFirstSubsequence(List<NSubsequence> sub) {
        int start = Integer.MAX_VALUE;
        int end = 0;
        for (NSubsequence s : sub) {
            if (s.getStart() < start) {
                start = s.getStart();
                end = s.getEnd();
            }
        }
        return new NSubsequence(start, end);
    }

    private static int bestLine(double maxError, int start, List<Double> data) {
        double error = Double.MIN_VALUE;
        int l = 3;// initial length
        int s = start;
        int size = data.size();
        int ret = start;
        while (error <= maxError) {
            int e = s + l - 1;
            if (e >= size - 1) {
                ret = size - 1;
                return ret;
            }
            List<Double> subList = data.subList(s, e + 1);
            double[] y = Utils.listToArray(subList);
            double[] x = new double[l];
            for (int i = 0; i < l; i++) {
                x[i] = 0 + i;// start + i
            }
            double[] reg = LinearRegression.regress(x, y);
            error = reg[2];
            ret = e - 1;
            l++;
        }
        return ret;
    }

    private static class Buffer {

        public int begin;
        public int end;

        public Buffer(int begin, int end) {
            this.begin = begin;
            this.end = end;
        }
    }

    private static List<NSubsequence> segmentationForBuffer(int start, List<Double> data, double e1) {
        List<NSubsequence> ret = new ArrayList<NSubsequence>();
        List<Double> mergeCost = new ArrayList<Double>();
        int length = data.size();
        int i;
        Utils.println("Init subsequence with length 2");
        for (i = 0; i < length - 1; i += 2) {
            ret.add(new NSubsequence(i, i + 1));
        }
        int sizeOfSub = ret.size();
        Utils.println("Calculate merge cost list");
        for (i = 0; i < sizeOfSub - 1; i++) {
            NSubsequence temp = new NSubsequence(ret.get(i).getStart(), ret.get(i + 1).getEnd());
            mergeCost.add(calculateErrorForBuffer(start, data, temp));
        }
        while (true) {
            MinMergCost cost = min(mergeCost);
            if (cost.min > e1) {
                break;
            }
            Utils.println("min cost: " + cost.min + ", min index: " + cost.index);
            Utils.println("Size subsequence: " + ret.size() + ", Size merge cost: " + mergeCost.size());
            NSubsequence m = ret.get(cost.index);
            NSubsequence mPlus1 = ret.get(cost.index + 1);
            m.setEnd(mPlus1.getEnd());
            if (cost.index + 1 < ret.size()) {
                ret.remove(cost.index + 1);
            }
            //update merger_code
            if (cost.index + 1 < mergeCost.size() && cost.index < ret.size() - 1) {
                mergeCost.remove(cost.index + 1);
                Double costi = calculateErrorForBuffer(start, data, m);
                mergeCost.set(cost.index, costi);
            } else {
                mergeCost.set(cost.index, Double.MAX_VALUE);
            }
            if (cost.index - 1 >= 0) {
                NSubsequence mMinus1 = ret.get(cost.index - 1);
                NSubsequence temp = new NSubsequence(mMinus1.getStart(), m.getEnd());
                mergeCost.set(cost.index - 1, calculateErrorForBuffer(start, data, temp));
            }
        }
        return ret;
    }

    private static double calculateErrorForBuffer(int start, List<Double> data, NSubsequence seq) {
        int s = seq.getStart();
        int e = seq.getEnd();
        int l = seq.getLength();

        List<Double> subList = data.subList(s, e + 1);
        double[] y = Utils.listToArray(subList);
        double[] x = new double[l];
        for (int i = 0; i < l; i++) {
            x[i] = 0 + 0 + i;//start + s + i;
        }
        double[] reg = LinearRegression.regress(x, y);
        return reg[2];
    }

    private static SWABSegmentation.MinMergCost min(List<Double> data) {
        double min = Double.MAX_VALUE;
        int index = 0;
        int size = data.size();
        for (int i = 0; i < size; i++) {
            if (min > data.get(i)) {
                min = data.get(i);
                index = i;
            }
        }
        return new SWABSegmentation.MinMergCost(index, min);
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
