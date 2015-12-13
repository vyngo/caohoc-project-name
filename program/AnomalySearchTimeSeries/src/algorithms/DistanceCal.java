/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package algorithms;

import chart.JChartSegment;
import common.SegmentationErrorCal;
import common.Utils;
import entity.NSubsequence;
import entity.NTimeSeries;
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import javax.swing.*;

/**
 *
 * @author Khanh Vy
 */
public class DistanceCal {

    public static double distance(double[] a, double[] b) {
        if (a.length == b.length) {
            return euclid(a, b);
        } else if (a.length > b.length) {
            double[] tmp = homothetic(a, b.length);
            return euclid(b, tmp);
        } else {
            double[] tmp = homothetic(b, a.length);
            return euclid(a, tmp);
        }
    }

    private static double euclid(double[] a, double[] b) {
        double ret = 0.0;
        double beta = 0.0;
        for (int i = 0; i < a.length; i++) {
            beta += (b[i] - a[i]);
        }
        beta = beta / a.length;
        for (int i = 0; i < a.length; i++) {
            double tmp = (a[i] - b[i] - beta) * (a[i] - b[i] - beta);
            ret += tmp;
        }
        return Math.sqrt(ret);
    }

    private static double[] homothetic(double[] data, int length) {
        double[] ret = new double[length];
        double y_max = Utils.max(data);
        double y_min = Utils.min(data);
        double x_center = (double) (data.length / 2);
        double y_center = (y_max + y_min) / 2.0;
        double ratio = (length * 1.0) / (data.length * 1.0);
        double X, Y;// data after homothetic
        double x, y;// original data
        int index = 0;
        for (X = (-(length / 2)) + x_center; (X < (length / 2) + x_center) || index < length; X++) {
            x = (X - x_center) / ratio + x_center;
            int round_x = ((int) x);
            if (round_x >= data.length - 1) {
                y = -(x - round_x) * data[round_x - 1] + (-round_x + 1 + x) * data[round_x];

            } else {
                y = (x - round_x) * data[round_x + 1] + (round_x + 1 - x) * data[round_x];
            }
            Y = (y - y_center) * ratio + y_center;
            ret[index] = Y;
            index++;
        }
        return ret;
    }

    public static void main(String[] args) throws Exception {
        // TODO code application logic here

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
            List<NSubsequence> subsequence = new ArrayList<NSubsequence>();
            List<Double> data = series.getData();
            double[] raw = new double[data.size()];
            for (i = 0; i < raw.length; i++) {
                raw[i] = data.get(i);
            }
            Utils.println("old length " + raw.length);
            int l = raw.length * 150 / 100;
            Utils.println("new length " + l);
            if (l == raw.length) {
                JChartSegment.drawChart(series, subsequence);
            } else {
                double[] newRaw = homothetic(raw, l);
                NTimeSeries news = new NTimeSeries();
                for (i = 0; i < l; i++) {
                    news.addData(newRaw[i]);
                }
                JChartSegment.drawChart(news, subsequence);
            }
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