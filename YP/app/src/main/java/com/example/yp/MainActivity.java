package com.example.yp;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.example.yp.Models.Employees;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MainActivity extends AppCompatActivity {

    Button SignIn_BT_signIn;

    SharedPreferences preferences;
    EditText Login_ET_signIn,Password_ET_signIn;
    ApiInterface apiInterface;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        SignIn_BT_signIn = findViewById(R.id.SignIn_BT_signIn);
        Login_ET_signIn = findViewById(R.id.Login_ET_signIn);
        Password_ET_signIn = findViewById(R.id.Password_ET_signIn);

        preferences = getSharedPreferences("token", MODE_PRIVATE);

        apiInterface = RequestBuilder.buildRequest();

        SignIn_BT_signIn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                Employees authUser = new Employees(Login_ET_signIn.getText().toString().trim(),Password_ET_signIn.getText().toString().trim());
                Call<Key> postAuth = apiInterface.postEmp(authUser);

                postAuth.enqueue(new Callback<Key>() {
                    @Override
                    public void onResponse(Call<Key> call, Response<Key> response) {
                        if(response.isSuccessful()){
                            Intent main = new Intent(getApplicationContext(), SecondActivity.class);
                            preferences.edit().putString("key",response.body().getAccess_token()).apply();

                            startActivity(main);
                            finish();
                        }
                        else {
                            Toast.makeText(getApplicationContext(),"Пользователь не найден!!!",Toast.LENGTH_LONG).show();
                        }
                    }

                    @Override
                    public void onFailure(Call<Key> call, Throwable t) {
                        Toast.makeText(getApplicationContext(),"Error",Toast.LENGTH_LONG).show();
                    }
                });
            }
        });
    }
}