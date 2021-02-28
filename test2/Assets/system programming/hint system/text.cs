using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{
    public GameObject hint_system;
    public Text instruction;
    Text message;
    public string[] messages;
    string Message;
    int message_lenght;
    int index=0;
    public float speed_of_text;
    float time;
    bool start;
    int msg_index=0;
    int number_of_msg;
    public float message_buffer_time;
    public float video_time;
    float time1;
    bool next_scene;
    // Start is called before the first frame update
    void Start()
    {
        Message=messages[msg_index];
        message_lenght=Message.Length;
        message=GetComponent<Text>();
        time=speed_of_text;
        number_of_msg=messages.Length;
        time1=video_time;
        start=true;
        next_scene=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(time1<0)
        {
            if(start)
            {
               start_Up();
            }
            Show_message();
            if(Input.GetKeyDown(KeyCode.Return))
            {
                message.text=messages[msg_index];
                index=message_lenght;
            }
        }
        else
        {
            time1-=Time.deltaTime;
        }
        if(next_scene && Input.GetKeyDown(KeyCode.Return))
        {
            end_up();
        }
        
        
    }

    void end_up()
    {
        start=true;
        time1=video_time;
        message.text=null;
        next_scene=false;
        instruction.text=null;
        gameObject.SetActive(false);
        hint_system.SetActive(true);
    }
    void start_Up()
    {
        msg_index=0;
        index=0;
        Message=messages[msg_index];
        message_lenght=Message.Length;
        time=speed_of_text;
        time1=video_time;
        start=false;
        instruction.text="Enter 'enter key' to skip";
    }
    void change_message()
    {
        if(msg_index<number_of_msg-1)
        {
            msg_index++;
            Message=messages[msg_index];
            message_lenght=Message.Length;
            index=0;
            message.text=null;
            
        }
        else
        {
            next_scene=true;
            instruction.text="Enter 'enter key' to close the scroll";
        }
    }

    void Show_message()
    {
        if(index<message_lenght)
        {
            time-=Time.deltaTime;
            if(time<0)
            {
                index++;
                time=speed_of_text;
                message.text=Message.Substring(0,index);
            }
        }
        else
        {
            time-=Time.deltaTime;
            if(time<=message_buffer_time*-1)
            {
                change_message();
            }
        }
    }
}
