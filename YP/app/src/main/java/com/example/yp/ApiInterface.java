package com.example.yp;

import com.example.yp.Models.Employees;
import com.example.yp.Models.Stock;

import java.util.ArrayList;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.Header;
import retrofit2.http.Headers;
import retrofit2.http.POST;
import retrofit2.http.Path;
import retrofit2.http.Query;

public interface ApiInterface {

    @POST("Employees/SignIn")
    Call<Key> postEmp(@Body Employees employees);

    @POST("Employees/refresh_token?")
    Call<Key> refresh (@Query("access_token")String access_token);
    @GET("Stocks")
    Call<ArrayList<Stock>> getStocks (@Header("Authorization") String access_token);

    @GET("Stocks/{id}")
    Call<Stock> getStockId(@Header("Authorization") String access_token,@Path("id") Integer id);

    @GET("Stocks?")
    Call<ArrayList<Stock>> getStocksSearch(@Header("Authorization") String access_token,@Query("Name") String Name);
}
