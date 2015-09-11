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
 * segmentation time series using M. Leng's method
 *
 * @author Khanh Vy
 */
public class QuaradicSegmentation {

    public static List<NSubsequence> segmentation(NTimeSeries series, double e1, double e2) {
        Utils.println("SEGMENTATION...");
        List<NSubsequence> ret = new ArrayList<NSubsequence>();
        boolean halt = false;
        int start = 0;
        do {
            NSubsequence sequence = getASegment(start, series, e1);
            ret.add(sequence);
            int end = sequence.getEnd();
            if (end == (series.getNumberOfDataPoint() - 1)) {
                halt = true;
            } else {
                start = getNextStartIndex(sequence, series, e2);
            }
        } while (!halt);
        Utils.println("FINISH...");
        return ret;
    }

    private static int getNextStartIndex(NSubsequence se, NTimeSeries series, double e2) {
        int start = se.getStart();
        int end = se.getEnd();
        int i = 1;
        List<Double> imageSubSequence = series.getData().subList(start, end + 1);
        List<Double> candidateSequence = series.getData().subList(start + i, end + i + 1);
        while (DistanceCal.distance(Utils.listToArray(imageSubSequence), Utils.listToArray(candidateSequence)) <= e2
                && i < (end - start)) {
            i++;
        }
        return end + i;
    }

    private static NSubsequence getASegment(int start, NTimeSeries series, double e1) {
        NSubsequence ret = null;
        boolean halt = false;
        int l = 4;// initial length
        int s = start;
        do {
            int e = s + l - 1;
            if (e >= series.getNumberOfDataPoint() - 1) {
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
                ret = new NSubsequence(start, e - 1);
            } else {
                l += 1;
            }
        } while (!halt);
        return ret;
    }
}
