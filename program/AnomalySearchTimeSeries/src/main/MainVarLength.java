/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package main;

import algorithms.VarLength;

/**
 *
 * @author Khanh Vy
 */
public class MainVarLength {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        String fileData = "data.txt";
        VarLength v = new VarLength(3.0, 1.0, 1);
        v.initData(fileData);
        v.run();
    }
}
