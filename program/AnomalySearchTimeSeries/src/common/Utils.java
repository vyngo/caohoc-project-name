/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package common;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.List;

/**
 *
 * @author Khanh Vy
 */
public class Utils {

    public static double[] listToArray(List<Double> lst) {
        if (lst == null) {
            return null;
        }
        double[] ret = new double[lst.size()];
        for (int i = 0; i < lst.size(); i++) {
            ret[i] = lst.get(i);
        }
        return ret;
    }

    public static double max(double[] a) {
        double ret = Double.MIN_VALUE;
        for (double d : a) {
            if (d > ret) {
                ret = d;
            }
        }
        return ret;
    }

    public static double min(double[] a) {
        double ret = Double.MAX_VALUE;
        for (double d : a) {
            if (d < ret) {
                ret = d;
            }
        }
        return ret;
    }
    
    public static double median(List<Double> s){
        List<Double> a = sortAsc(s);
        int size = a.size();
        int mid = size/2;
        return a.get(mid);
    }
    
    public static List<Double> sortAsc(List<Double> src){
        List<Double> ret = new ArrayList<Double>();
        for(double tmp : src){
            ret.add(tmp);
        }
        Collections.sort(ret);
        return ret;
    }
}
