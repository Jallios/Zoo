package com.example.yp;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.Spinner;
import android.widget.Toast;

import com.example.yp.Models.Stock;

import java.util.ArrayList;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class SearchActivity extends AppCompatActivity {

    RecyclerView recyclerView;
    ApiInterface apiInterface;

    Intent intent;
    RecycleAdapter.OnStateClickListener stateClickListener;

    EditText search_TV;

    SharedPreferences preferences;

    Button search_BT;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_search);

        recyclerView = findViewById(R.id.recycle_view_search);
        search_TV = findViewById(R.id.search_TV);
        search_BT = findViewById(R.id.search_BT);
        apiInterface = RequestBuilder.buildRequest();

        preferences = getSharedPreferences("token", MODE_PRIVATE);

        String access_token = preferences.getString("key","");

        stateClickListener = new RecycleAdapter.OnStateClickListener() {
            @Override
            public void onStateClick(Stock state, int position) {
                Intent intent = new Intent(getApplicationContext(), StockActivity.class);
                intent.putExtra("item",state.getIdComponent());
                intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                startActivity(intent);
            }

        };

        String Name = search_TV.getText().toString();

        search_BT.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Call<ArrayList<Stock>> getArticlesSearch = apiInterface.getStocksSearch("Bearer " + access_token,Name );

                getArticlesSearch.enqueue(new Callback<ArrayList<Stock>>() {
                    @Override
                    public void onResponse(Call<ArrayList<Stock>> call, Response<ArrayList<Stock>> response) {
                        if(response.isSuccessful()){
                            recyclerView.setLayoutManager(new LinearLayoutManager(getApplicationContext()));
                            recyclerView.setHasFixedSize(true);
                            ArrayList<Stock> articles = response.body();
                            RecycleAdapter adapter = new RecycleAdapter(getApplicationContext(),articles,stateClickListener);
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
                            Toast.makeText(getApplicationContext(),"Error",Toast.LENGTH_LONG).show();
                        }
                    }

                    @Override
                    public void onFailure(Call<ArrayList<Stock>> call, Throwable t) {
                        Toast.makeText(getApplicationContext(),t.getMessage(),Toast.LENGTH_LONG).show();
                    }
                });
            }
        });
    }
}