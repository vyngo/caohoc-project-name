/* ===========================================================
 * JChart : a free chart library for the Java(tm) platform
 * ===========================================================
 *
 * (C) Copyright 2000-2004, by Object Refinery Limited and Contributors.
 *
 * Project Info:  http://www.jfree.org/jfreechart/index.html
 *
 * This library is free software; you can redistribute it and/or modify it under the terms
 * of the GNU Lesser General Public License as published by the Free Software Foundation;
 * either version 2.1 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 * See the GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License along with this
 * library; if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330,
 * Boston, MA 02111-1307, USA.
 *
 * [Java is a trademark or registered trademark of Sun Microsystems, Inc. 
 * in the United States and other countries.]
 *
 * --------------------
 * TimeSeriesDemo5.java
 * --------------------
 * (C) Copyright 2001-2004, by Object Refinery Limited and Contributors.
 *
 * Original Author:  David Gilbert (for Object Refinery Limited);
 * Contributor(s):   -;
 *
 * $Id: TimeSeriesDemo5.java,v 1.12 2004/04/26 19:12:03 taqua Exp $
 *
 * Changes (from 24-Apr-2002)
 * --------------------------
 * 24-Apr-2002 : Added standard header (DG);
 * 10-Oct-2002 : Renamed JFreeChartDemo2 --> TimeSeriesDemo5 (DG);
 *
 */
package chart;

import java.awt.Color;
import java.awt.Paint;
import java.text.SimpleDateFormat;
import java.util.List;
import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartPanel;
import org.jfree.chart.JFreeChart;
import org.jfree.chart.axis.DateAxis;
import org.jfree.chart.plot.XYPlot;
import org.jfree.chart.renderer.xy.XYItemRenderer;
import org.jfree.chart.renderer.xy.XYLineAndShapeRenderer;
import org.jfree.data.general.SeriesException;
import org.jfree.data.xy.XYDataset;
import org.jfree.data.xy.XYSeries;
import org.jfree.data.xy.XYSeriesCollection;
import org.jfree.ui.ApplicationFrame;
import org.jfree.ui.RefineryUtilities;

/**
 * A time series chart with 4000 data points, to get an idea of how JChart
 * performs with a larger dataset. You can see that it slows down significantly,
 * so this needs to be worked on (4000 points is not that many!).
 *
 */
public class JChart extends ApplicationFrame {

    /**
     * Creates a new demo instance.
     *
     * @param title the frame title.
     */
    public JChart(final String title, List<Double> data) {
        super(title);
        final XYDataset dataset = createDataset(data);
        final JFreeChart chart = createChart(dataset);
        final ChartPanel chartPanel = new ChartPanel(chart);
        chartPanel.setPreferredSize(new java.awt.Dimension(500, 270));
        chartPanel.setMouseZoomable(true, false);
        setContentPane(chartPanel);

    }

    /**
     * Creates a sample dataset.
     *
     * @return A sample dataset.
     */
    private XYDataset createDataset(List<Double> data) {

        final XYSeries series = new XYSeries("Data");
        int length = data.size();
        for (int i = 0; i < length; i++) {
            try {
                series.add(i, data.get(i));
            } catch (SeriesException e) {
                e.printStackTrace(System.out);
            }
        }
        return new XYSeriesCollection(series);
    }

    /**
     * Creates a sample chart.
     *
     * @param dataset the dataset.
     *
     * @return A sample chart.
     */
    private JFreeChart createChart(final XYDataset dataset) {
        final JFreeChart chart = ChartFactory.createTimeSeriesChart(
                "Test",
                "Time",
                "Value",
                dataset,
                false,
                false,
                false);
        chart.setBackgroundPaint(Color.WHITE);
        final XYPlot plot = chart.getXYPlot();
        plot.setBackgroundPaint(Color.white);
        plot.setDomainGridlinePaint(Color.white);
        plot.setDomainCrosshairVisible(true);
        plot.setRangeCrosshairVisible(true);
//        MyRender renderer = new MyRender(dataset);
//        plot.setRenderer(renderer);
        XYLineAndShapeRenderer render = new XYLineAndShapeRenderer();
        render.setSeriesShapesVisible(0, false);
        chart.setBackgroundPaint(Color.white);
        DateAxis axis = (DateAxis) plot.getDomainAxis();
//        axis.setDateFormatOverride(new SimpleDateFormat("SSS"));
        axis.setVisible(false);


        return chart;
    }

    private static class MyRender extends XYLineAndShapeRenderer {

        XYDataset dataset;

        public MyRender(XYDataset dataset) {
            this.dataset = dataset;
        }

        @Override
        public Paint getItemPaint(int row, int col) {
            Paint cpaint = getItemColor(row, col);
            if (cpaint == null) {
                cpaint = super.getItemPaint(row, col);
            }
            return cpaint;
        }

        public Color getItemColor(int row, int col) {
            System.out.println(col + "," + dataset.getY(row, col));
            double x = dataset.getXValue(row, col);
            if (x <= 100) {
                return Color.black;
            } else {
                return Color.red;
            }
        }
    }

    public static void drawTimeSeries(List<Double> data) {

        final String title = "Time Series";
        final JChart demo = new JChart(title, data);
        demo.pack();
        RefineryUtilities.positionFrameRandomly(demo);
        demo.setVisible(true);

    }
}