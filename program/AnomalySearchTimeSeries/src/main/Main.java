/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package main;

import algorithms.VarLength;
import entity.NTimeSeries;

/**
 *
 * @author Khanh Vy
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        String fileData = "data.txt";
        VarLength v = new VarLength();
        v.initData(fileData);
        v.run();
    }
}
