/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package common;

import algorithms.LinearRegression;
import entity.NSubsequence;
import entity.NTimeSeries;
import java.util.List;

/**
 *
 * @author Khanh Vy
 */
public class SegmentationErrorCal {
    
    public static double calErrorByPiecewsie(List<NSubsequence> seq, NTimeSeries series){
        double error = 0.0;
        for(NSubsequence s : seq){
            int start = s.getStart();
            int end = s.getEnd();
            int l = s.getLength();
            List<Double> subList = series.getData().subList(start, end + 1);
            double[] y = Utils.listToArray(subList);
            double[] x = new double[l];
            for (int i = 0; i < l; i++) {
                x[i] = 0 + i;//start + i;
            }
            double[] reg = LinearRegression.regress(x, y);
            error += reg[2];
        }
        return error;
    }
}
