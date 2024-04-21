package com.stud.onu.edu.ua.zodiact;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class FirstSlide extends AppCompatActivity {

    private Button buttonIn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_first_slide);
        buttonIn = findViewById(R.id.buttonIn);

        buttonIn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent("activity_second_slide");
                startActivity(intent);
            }
        });
    }

}