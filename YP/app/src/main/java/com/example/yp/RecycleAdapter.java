package com.example.yp;

import android.annotation.SuppressLint;
import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.yp.Models.Stock;

import java.util.ArrayList;

public class RecycleAdapter extends RecyclerView.Adapter<RecycleAdapter.ViewHolder> {

    private Context context;
    private ArrayList<Stock> StockArrayList;
    private Intent intent;

    interface OnStateClickListener{
        void onStateClick(Stock state, int position);
    }

    private final OnStateClickListener onClickListener;

    public RecycleAdapter(Context context, ArrayList<Stock> stockArrayList, OnStateClickListener onClickListener){
        this.context = context;
        this.StockArrayList = stockArrayList;
        this.onClickListener = onClickListener;
    }

    @NonNull
    @Override
    public RecycleAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(context).inflate(R.layout.item_card, parent, false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull RecycleAdapter.ViewHolder holder, @SuppressLint("RecyclerView") int position) {
        Stock stock = StockArrayList.get(position);
        holder.NameComponent_TV.setText(stock.getNameComponent());
        holder.Quality_TV.setText(String.valueOf(stock.getQuality()));
        holder.itemView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                onClickListener.onStateClick(stock,position);

            }
        });

    }

    @Override
    public int getItemCount() {
        return StockArrayList.size();
    }

    public static class ViewHolder extends RecyclerView.ViewHolder{

        TextView NameComponent_TV;
        TextView Quality_TV;


        ViewHolder(View view) {
            super(view);
            NameComponent_TV = view.findViewById(R.id.NameComponent_TV);
            Quality_TV = view.findViewById(R.id.Quality_TV);

        }

    }
}
