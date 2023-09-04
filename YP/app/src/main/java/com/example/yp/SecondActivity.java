package com.example.yp;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Toast;

import com.example.yp.Models.Stock;
import com.google.android.material.floatingactionbutton.FloatingActionButton;

import java.util.ArrayList;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class SecondActivity extends AppCompatActivity {

    RecyclerView recyclerView;
    FloatingActionButton floatingActionButton;
    ApiInterface apiInterface;

    SharedPreferences preferences;
    RecycleAdapter.OnStateClickListener stateClickListener;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_second);

        preferences = getSharedPreferences("token", MODE_PRIVATE);

        String access_token = preferences.getString("key","");
        Log.d("mawi", access_token);

        recyclerView = findViewById(R.id.recycle_view_first);
        floatingActionButton = findViewById(R.id.to_search);
        apiInterface = RequestBuilder.buildRequest();

        floatingActionButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(getApplicationContext(), SearchActivity.class);
                startActivity(intent);
            }
        });



        Call<ArrayList<Stock>> getStock = apiInterface.getStocks("Bearer " + access_token);

        stateClickListener = new RecycleAdapter.OnStateClickListener() {
            @Override
            public void onStateClick(Stock state, int position) {
                Intent intent = new Intent(getApplicationContext(), StockActivity.class);
                intent.putExtra("item",state.getIdComponent());
                intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                startActivity(intent);
            }

        };

        getStock.enqueue(new Callback<ArrayList<Stock>>() {
            @Override
            public void onResponse(Call<ArrayList<Stock>> call, Response<ArrayList<Stock>> response) {
                if(response.isSuccessful()){
                    recyclerView.setLayoutManager(new LinearLayoutManager(SecondActivity.this));
                    recyclerView.setHasFixedSize(true);
                    ArrayList<Stock> stock = response.body();
                    RecycleAdapter adapter = new RecycleAdapter(SecondActivity.this,stock,stateClickListener);
                    recyclerView.setAdapter(adapter);
                }
                else if(response.code() == 401)
                {
                    Call<Key> refresh = apiInterface.refresh(access_token);
                    refresh.enqueue(new Callback<Key>() {
                        @Override
                        public void onResponse(Call<Key> call, Response<Key> response) {
                            if(response.isSuccessful()){
                                preferences.edit().putString("key",response.body().getAccess_token()).apply();
                            }
                        }

                        @Override
                        public void onFailure(Call<Key> call, Throwable t) {

                        }
                    });
                }
                else{
                    Toast.makeText(SecondActivity.this,"Error",Toast.LENGTH_LONG).show();
                }
            }

            @Override
            public void onFailure(Call<ArrayList<Stock>> call, Throwable t) {
                Toast.makeText(SecondActivity.this,t.getMessage(),Toast.LENGTH_LONG).show();
            }
        });
    }
}