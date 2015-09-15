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
        rawData = new ArrayList<Double>();
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
        rawData = new ArrayList<Double>();
    }

    public int getNumberOfDataPoint() {
        return data.size();
    }

    public void addData(double val) {
        if (data != null) {
            data.add(val);
        }
        if(rawData != null){
            rawData.add(val);
        }
    }

    public List<Double> getData() {
        return data;
    }
    
    public List<Double> getRawData(){
        return rawData;
    }

}
