package be.happli.samuelscholtes.geoexample;

import android.app.Activity;
import android.content.Intent;
import android.net.Uri;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);


    }



    public void showMapAndMarker(View view){
        //Uri gmmIntentUri = Uri.parse("geo:37.7749,-122.4194");
        Uri gmmIntentUri = Uri.parse("geo:0,0?q=Rue+Charles+Zoude+5000+Namur");
        Intent mapIntent = new Intent(Intent.ACTION_VIEW, gmmIntentUri);
        mapIntent.setPackage("com.google.android.apps.maps");
        startActivity(mapIntent);

    }

    public void navigate(View view){
        //Uri gmmIntentUri = Uri.parse("geo:37.7749,-122.4194");
        Uri gmmIntentUri = Uri.parse("google.navigation:q=Rue+Joseph+Calozet+5000+Namur");
        Intent mapIntent = new Intent(Intent.ACTION_VIEW, gmmIntentUri);
        mapIntent.setPackage("com.google.android.apps.maps");
        startActivity(mapIntent);



    }

    public void showMapInApp(View view){
        Intent intent = new Intent(this, MapsActivity.class);

        startActivity(intent);
    }
}
