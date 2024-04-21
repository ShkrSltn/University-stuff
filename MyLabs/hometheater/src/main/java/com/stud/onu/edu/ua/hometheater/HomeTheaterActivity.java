package com.stud.onu.edu.ua.hometheater;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.ImageView;

public class HomeTheaterActivity<ImageView> extends AppCompatActivity {
public ImageView imgview;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home_theater);
    }
}