/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package entity;

import chart.JChart;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Khanh Vy
 */
public class NTimeSeries {

    private List<Double> data = null;

    public NTimeSeries() {
        data = new ArrayList<Double>();
    }

    public void clear() {
        if (data != null) {
            data.clear();
            data = null;
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

}
