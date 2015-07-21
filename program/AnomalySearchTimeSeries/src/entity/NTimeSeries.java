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
    private List<NSubsequence> anomalyPatterns = null;
    

    public NTimeSeries() {
        data = new ArrayList<Double>();
        anomalyPatterns = new ArrayList<NSubsequence>();
    }
    
    public void clear(){
        if(data != null){
            data.clear();
            data = null;
        }
        if(anomalyPatterns != null){
            anomalyPatterns.clear();
            anomalyPatterns = null;
        }
    }
    
    public void reInitiate(){
        clear();
        data = new ArrayList<Double>();
        anomalyPatterns = new ArrayList<NSubsequence>();
    }
    
    public int getNumberOfDataPoint(){
        return data.size();
    } 
}
