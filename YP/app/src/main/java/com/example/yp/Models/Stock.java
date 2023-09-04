package com.example.yp.Models;

import java.text.DecimalFormat;

public class Stock {

    private int idComponent;
    private String nameComponent;
    private double quality;

    public Stock(int idComponent, String nameComponent, double quality) {
        this.idComponent = idComponent;
        this.nameComponent = nameComponent;
        this.quality = quality;
    }

    public int getIdComponent() {
        return idComponent;
    }

    public void setIdComponent(int idComponent) {
        this.idComponent = idComponent;
    }

    public String getNameComponent() {
        return nameComponent;
    }

    public void setNameComponent(String nameComponent) {
        this.nameComponent = nameComponent;
    }

    public double getQuality() {
        return quality;
    }

    public void setQuality(double quality) {
        this.quality = quality;
    }
}
