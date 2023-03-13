import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.json.simple.JSONArray;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;

import java.io.*;
import java.util.*;

public class parser {
    public static void main(String[] args) throws IOException, ParseException {
        BufferedReader bufReader = new BufferedReader(new FileReader("/Users/xuyingwang/IdeaProjects/PiqueCloud/src/files/ubuntu.txt"));
        ArrayList<String> listOfLines = new ArrayList<>();
        String line = bufReader.readLine();
        while (line != null) { listOfLines.add(line); line = bufReader.readLine(); }
        bufReader.close();
        SortedMap<Integer, Map<String, String>> rightHereMap = new TreeMap<>();
        JSONParser parser = new JSONParser();
        JSONArray jsonArray = (JSONArray) parser.parse(new FileReader("/Users/xuyingwang/IdeaProjects/PiqueCloud/src/files/meta/ubuntu.json"));
        rightHereMap = createMap(listOfLines, jsonArray);
        ObjectMapper objectMapper = new ObjectMapper();


        try {
            FileWriter file = new FileWriter("/Users/xuyingwang/IdeaProjects/PiqueCloud/src/output/ubuntu.json");
            String json = objectMapper.writeValueAsString( rightHereMap);
            file.write(json);
            file.close();
        } catch (JsonProcessingException e) {
            e.printStackTrace();
        }
    }

    public static  SortedMap<Integer, Map<String, String>>  createMap(ArrayList<String> listOfLines, JSONArray jsonArray)
    {
        SortedMap<Integer, Map<String, String>> result = new TreeMap<>();

        Iterator<String> iterator = jsonArray.iterator();
        SortedMap<Integer, String> info = new TreeMap<>();
        int index = 1;
        while (iterator.hasNext())
        {
            info.put(index, iterator.next());
            index++;
        }
        for (int i = 0; i < listOfLines.size(); i++){
            int j = i + 1;
            Map<String, String> myMap = new HashMap<>();
            myMap.put(listOfLines.get(i), info.get(j));
            result.put(j, myMap);
        }
       return result;
    }
}
