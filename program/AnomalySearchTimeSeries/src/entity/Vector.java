/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package entity;

/**
 *
 * @author Khanh Vy
 */
public class Vector {

    double x;
    double y;

    public Vector(double x, double y) {
        this.x = x;
        this.y = y;
    }
    
    public Vector(Point p1, Point p2){
        this.x = p2.getX() - p1.getX();
        this.y = p2.getY() - p1.getY();
    }

    public double getX() {
        return x;
    }

    public double getY() {
        return y;
    }

    public void setX(double x) {
        this.x = x;
    }

    public void setY(double y) {
        this.y = y;
    }
}
