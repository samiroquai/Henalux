package be.happli.samuelscholtes.httpdemo;


import android.app.DownloadManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);





        // Instantiate the RequestQueue.
        RequestQueue queue = Volley.newRequestQueue(this);
        String appId="VOTRE_CLE_ICI";
        String url = "http://api.openweathermap.org/data/2.5/forecast?q=Namur,be&units=metric&lang=fr&appid="+appId;

        // Request a string response from the provided URL.
        StringRequest stringRequest = new StringRequest(Request.Method.GET, url,
                new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        // Display the first 500 characters of the response string.
                        Log.d("http","réponse reçue: "+response);
                        if (response != null) {
                            try {
                                JSONObject jsonObj = new JSONObject(response);

                                // Getting JSON Array node
                                JSONArray jsonForecasts = jsonObj.getJSONArray("list");
                                Forecast[] forecasts=new Forecast[jsonForecasts.length()];
                                // looping through All Contacts
                                for (int i = 0; i < jsonForecasts.length(); i++) {
                                    JSONObject c = jsonForecasts.getJSONObject(i);
                                    JSONObject main=c.getJSONObject("main");
                                    //Log.d("json",main.toString());
                                    Double minTemp = main.getDouble("temp_min");
                                    Double maxTemp = main.getDouble("temp_max");

                                    Forecast forecast=new Forecast(minTemp,maxTemp);
                                    forecasts[i]=forecast;
                                }




                                ArrayAdapter<Forecast> itemsAdapter =
                                        new ArrayAdapter<Forecast>(getBaseContext(),
                                                android.R.layout.simple_list_item_1,
                                                forecasts);
                                ListView listView = (ListView) findViewById(R.id.listItem);
                                listView.setAdapter(itemsAdapter);

                            }
                            catch (final JSONException e) {
                                Log.e("json", "Json parsing error: " + e.getMessage());
                                runOnUiThread(new Runnable() {
                                    @Override
                                    public void run() {
                                        Toast.makeText(getApplicationContext(),
                                                "Json parsing error: " + e.getMessage(),
                                                Toast.LENGTH_LONG)
                                                .show();
                                    }
                                });

                            }
                        }
                    }
                }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Log.d("http","erreur reçue: "+error);
            }
        });
// Add the request to the RequestQueue.
        queue.add(stringRequest);
    }
}
