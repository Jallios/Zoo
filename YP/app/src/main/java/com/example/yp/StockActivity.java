package com.example.yp;

import androidx.appcompat.app.AppCompatActivity;

import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import com.example.yp.Models.Stock;
import com.google.android.material.floatingactionbutton.FloatingActionButton;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class StockActivity extends AppCompatActivity {

    TextView TVComponent_Name, TVComponent_Quality;

    ApiInterface apiInterface;

    Integer id;

    SharedPreferences preferences;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_stock);

        preferences = getSharedPreferences("token", MODE_PRIVATE);

        String access_token = preferences.getString("key","");

        TVComponent_Name = findViewById(R.id.TVComponent_Name);
        TVComponent_Quality = findViewById(R.id.TVComponent_Quality);

        apiInterface = RequestBuilder.buildRequest();
        id = getIntent().getIntExtra("item",0);

        Call<Stock> getStockId = apiInterface.getStockId("Bearer " + access_token,id);

        getStockId.enqueue(new Callback<Stock>() {
            @Override
            public void onResponse(Call<Stock> call, Response<Stock> response) {
                if(response.isSuccessful()) {
                    Stock stock = response.body();

                    TVComponent_Name.setText(stock.getNameComponent());
                    TVComponent_Quality.setText(String.valueOf(stock.getQuality()));

                }else
                {
                    Toast.makeText(getApplicationContext(), "Error", Toast.LENGTH_LONG).show();
                }
            }
            @Override
            public void onFailure(Call<Stock> call, Throwable t) {
                Toast.makeText(getApplicationContext(),t.getMessage(),Toast.LENGTH_LONG).show();
            }
        });
    }
}