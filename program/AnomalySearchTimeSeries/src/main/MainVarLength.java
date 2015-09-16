/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package main;

import algorithms.VarLength;
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import javax.swing.*;

/**
 *
 * @author Khanh Vy
 */
public class MainVarLength {

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
        VarLength v = new VarLength(3.0, 1.0);
        v.initData(fileData);
        v.run();
    }
}
