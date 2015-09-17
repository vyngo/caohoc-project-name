/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package entity;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Khanh Vy
 */
public class NTimeSeries {

    private List<Double> data = null;
    private List<Double> rawData = null;

    public NTimeSeries() {
        data = new ArrayList<Double>();
    }

    public void clear() {
        if (data != null) {
            data.clear();
            data = null;
        }
        if(rawData != null){
            rawData.clear();
            rawData = null;
        }
    }

    public void reInitiate() {
        clear();
        data = new ArrayList<Double>();
    }

    public int getNumberOfDataPoint() {
        return data.size();
    }

    public void addData(double val) {
        if (data != null) {
            data.add(val);
        }
    }

    public List<Double> getData() {
        return data;
    }
    
    public List<Double> getRawData(){
        return rawData;
    }
    
    public void zscore(){
        rawData = new ArrayList<Double>();
        //backup
        for(double a : data){
            rawData.add(a);
        }
        double mean = mean();
        double std = std();
        data.clear();
        data = new ArrayList<Double>();
        for(double a : rawData){
            double s = (a - mean) / std;
            data.add(s);
        }
    }
    
    public double mean(){
        double ret = 0.0;
        for(double a : data){
            ret += a;
        }
        return ret / data.size();
    }
    
    public double std(){
        double ret = 0.0;
        double mean = mean();
        for(double a : data){
            ret += (a-mean) * (a-mean);
        }
        ret = ret / ((double)data.size());
        return Math.sqrt(ret);
    }
}
