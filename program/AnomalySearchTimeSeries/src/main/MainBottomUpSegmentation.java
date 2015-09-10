/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package main;

import algorithms.BottomUpSegmentation;
import chart.JChartSegment;
import common.SegmentationErrorCal;
import common.Utils;
import entity.NSubsequence;
import entity.NTimeSeries;
import java.io.File;
import java.util.List;
import java.util.Scanner;

/**
 *
 * @author Khanh Vy
 */
public class MainBottomUpSegmentation {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        Utils.println("RUNNING...");
        String fileData = "data.txt";
        Scanner scanner = null;
        NTimeSeries series = new NTimeSeries();
        try {
            // Location of file to read
            File file = new File(fileData);
            scanner = new Scanner(file);
            int i = 0;
            while (scanner.hasNextLine()) {
                i++;
                String draw = scanner.nextLine();
                String line = draw.trim();
                series.addData(Double.parseDouble(line));
            }
            List<NSubsequence> subsequence = BottomUpSegmentation.segmentation(series, 3.0);
            Utils.println("================= RESULT ==============================");
            Utils.println("size: " + subsequence.size());
            for(NSubsequence s : subsequence){
                Utils.printSegment(s);
            }
            double err = SegmentationErrorCal.calErrorByPiecewsie(subsequence, series);
            Utils.print("Error: " + err);
            JChartSegment.drawChart(series, subsequence);
            scanner.close();
        } catch (Exception ex) {
            ex.printStackTrace(System.out);
        } finally {
            if (scanner != null) {
                scanner.close();
            }
        }
    }
}
