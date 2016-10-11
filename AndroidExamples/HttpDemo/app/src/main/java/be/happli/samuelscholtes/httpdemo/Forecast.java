package be.happli.samuelscholtes.httpdemo;

/**
 * Created by samuelscholtes on 11/10/16.
 */
public class Forecast {
    private Double minTemp;
    private Double maxTemp;

    public Forecast(Double minTemp,Double maxTemp)
    {
        this.minTemp=minTemp;
        this.maxTemp=maxTemp;
    }

    public Double getMinTemp() {
        return minTemp;
    }

    public Double getMaxTemp() {
        return maxTemp;
    }

    @Override
    public String toString() {
        return "Min.: "+getMinTemp()+"°; Max.: "+getMaxTemp()+"°";
    }
}
