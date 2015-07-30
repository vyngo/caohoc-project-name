/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package algorithms;

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

    private List<NSubsequence> segmentation() {
        List<NSubsequence> ret = new ArrayList<NSubsequence>();
        boolean halt = false;
        do{
            int l = 4;// initial length
            int s = 0;
            int e = s + l -1;
            int m = s;
            
        }while(!halt);
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
                if(i == 1){
                    e1 = Double.parseDouble(line);
                }else if(i == 2){
                     e2 = Double.parseDouble(line);
                }else{
                    series.addData(Double.parseDouble(line));
                }
            }
            scanner.close();
        } catch (Exception ex) {
            ex.printStackTrace(System.out);
        } finally {
            if(scanner != null){
                scanner.close();
            }
        }
    }
}
