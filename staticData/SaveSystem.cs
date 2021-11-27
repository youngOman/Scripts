using System.Collections.Generic; //泛型使用
using System.IO; //使用FileStream前Import Access File
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary; //將物件序列化和還原序列化為二進位格式。
using UnityEngine.SceneManagement;
//Does not saving
public class SaveSystem : MonoBehaviour
{
    public static List<Fish> fishes=new List<Fish>(); //static能在任何地方存取
    [SerializeField] Fish AnyFish; //繼承Fish Class回傳value，name
    const string Fish_URL="/fish";
    const string Fish_COUNT_URL="/fish.count";

    void OnApplicationPause(bool pause)
    {
        SaveFish();
    }
    void SaveFish(){
        BinaryFormatter formatter = new BinaryFormatter();
        string path=Application.persistentDataPath+Fish_URL; // 存值在各個Scene
        //將此場景已經有的魚儲存以免Reload
        string countPath=Application.persistentDataPath+Fish_COUNT_URL; //SceneManager.GetActiveScene().buildIndex 存值在各個Scene 
        FileStream countStream=new FileStream(countPath,FileMode.Create);
        formatter.Serialize(countStream,fishes.Count);
        countStream.Close(); //存完要關檔，以免出錯 

        for (int i = 0; i < fishes.Count; i++)
        {
            FileStream stream = new FileStream(path+i,FileMode.Create); //建立檔案
            FishData data =new FishData(fishes[i]); //將每隻魚帶入Fish建構式
            formatter.Serialize(stream,data); //Serialize=存入 將data寫入檔案
            stream.Close();
        }
    }
    void loadFishData(){
        BinaryFormatter formatter = new BinaryFormatter(); //這裡reload=重新開始遊戲，List就會Reset沒有魚，
        string path=Application.persistentDataPath+Fish_COUNT_URL; //SceneManager.GetActiveScene().buildIndex 存值在各個Scene
        string countPath=Application.persistentDataPath+Fish_COUNT_URL; //SceneManager.GetActiveScene().buildIndex 存值在各個Scene 
        int fishCount=0;
        if(File.Exists(countPath)){ //如果檔案存在
            FileStream countStream=new FileStream(countPath,FileMode.Open);
            fishCount=(int)formatter.Deserialize(countStream); //將二進位資料流還原至物件圖形。
            countStream.Close(); //一定要關!!!!  
        }else{
            Debug.Log("找不到路徑"+countPath);
        }
        for (int i = 0; i < fishes.Count; i++)
        {
            if(File.Exists(path+i)){ //如果檔案存在
                FileStream stream=new FileStream(path+i,FileMode.Open); //打開在上面建立好的stream檔
                FishData data=formatter.Deserialize(stream) as FishData; //將二進位資料還原傳給FishData
                stream.Close();
                //傳值進儲存魚的價值及資訊的Fish建構式
                Fish fish=Instantiate(AnyFish); 
                // fish.value=data.value;
                // fish.FishName=data.FishName;
            }else{
               Debug.Log("找不到路徑"+(path+i)); 
            }
            
        }
    }
}
