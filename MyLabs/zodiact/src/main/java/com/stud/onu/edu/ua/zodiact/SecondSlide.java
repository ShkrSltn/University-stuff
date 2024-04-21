package com.stud.onu.edu.ua.zodiact;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class SecondSlide extends AppCompatActivity {
    private Button buttonCheck;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_second_slide);
        buttonCheck = findViewById(R.id.buttonCheck);

        buttonCheck.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent("activity_third_slide");
                startActivity(intent);
                //buttonCheck.setBackgroundColor(Color.BLUE);
            }

        });



    }
}