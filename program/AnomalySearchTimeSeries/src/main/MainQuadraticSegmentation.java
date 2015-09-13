/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package main;

import algorithms.QuaradicSegmentation;
import chart.JChartSegment;
import common.SegmentationErrorCal;
import common.Utils;
import entity.NSubsequence;
import entity.NTimeSeries;
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import java.util.List;
import java.util.Scanner;
import javax.swing.*;

/**
 *
 * @author Khanh Vy
 */
public class MainQuadraticSegmentation {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws Exception {
        UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName());

        JFrame.setDefaultLookAndFeelDecorated(true);
        JDialog.setDefaultLookAndFeelDecorated(true);
        JFrame frame = new JFrame("JComboBox Test");
        frame.setLayout(new FlowLayout());
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        JButton button = new JButton("Select File");
        button.addActionListener(new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent ae) {
                JFileChooser fileChooser = new JFileChooser();
                int returnValue = fileChooser.showOpenDialog(null);
                if (returnValue == JFileChooser.APPROVE_OPTION) {
                    File selectedFile = fileChooser.getSelectedFile();
                    run(selectedFile.getPath());
                }
            }
        });
        frame.add(button);
        frame.pack();
        frame.setVisible(true);
    }

    private static void run(String fileData) {
        // TODO code application logic here
        Utils.println("RUNNING...");
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
            List<NSubsequence> subsequence = QuaradicSegmentation.segmentation(series, 3.0, 1.0);
            Utils.println("================= RESULT ==============================");
            Utils.println("size: " + subsequence.size());
            for (NSubsequence s : subsequence) {
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
