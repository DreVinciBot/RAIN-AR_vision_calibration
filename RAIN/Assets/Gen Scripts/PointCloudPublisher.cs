using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using UnityEngine.UI;
using System;
using TMPro;


namespace RosSharp.RosBridgeClient
{
    public class PointCloudPublisher : MonoBehaviour
    {
        public string Topic;
        public Text voxelValue;
       // public PointCloudReceiver MessageProvider;
        public RosConnector rosConnector;

        private RosSocket rosSocket;
        private string publicationId;

        //private int publicationId;

        //private StandardString Message;
        private GeometryPoint Message;
     
        private float current_voxelSize;

        private void Start()
        {
            current_voxelSize = float.Parse(voxelValue.text, System.Globalization.CultureInfo.InvariantCulture);
            rosSocket = rosConnector.RosSocket;
            //publicationId = rosSocket.Advertise(Topic, MessageTypes.RosMessageType(MessageProvider.MessageType));
            publicationId = rosSocket.Advertise(Topic, "geometry_msgs/Point");
            //publicationId = rosSocket.Advertise(Topic, "std_msgs/String");

            Message = new GeometryPoint();
         

        }

        public void btn_rightPressed()
        {
            current_voxelSize = current_voxelSize + 0.05f;
            voxelValue.text = current_voxelSize.ToString();
            //Debug.Log("right button pressed");
            Message.x = current_voxelSize;
            //Message.data = current_voxelSize;
            rosSocket.Publish(publicationId, Message);

        }

        public void btn_leftPressed()
        {
            current_voxelSize = current_voxelSize - 0.05f;
            voxelValue.text = current_voxelSize.ToString();
            // Debug.Log("left button pressed");

            Message.x = current_voxelSize;
            rosSocket.Publish(publicationId, Message);

        }

    }
}