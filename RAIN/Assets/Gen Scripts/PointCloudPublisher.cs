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
        public string Topic2;
        public Text voxelValue;
        public Text radiusValue;
        public RosConnector rosConnector;

        private RosSocket rosSocket;
        private string publicationId2;
        private string publicationId;
        private GeometryPoint Message;
        private float current_voxelSize;
        private float current_radiusLimit;

        private void Start()
        {
            current_voxelSize = float.Parse(voxelValue.text, System.Globalization.CultureInfo.InvariantCulture);
            current_radiusLimit = float.Parse(radiusValue.text, System.Globalization.CultureInfo.InvariantCulture);

            rosSocket = rosConnector.RosSocket;
            //publicationId = rosSocket.Advertise(Topic, MessageTypes.RosMessageType(MessageProvider.MessageType));
            publicationId2 = rosSocket.Advertise(Topic2, "geometry_msgs/Point");
            publicationId = rosSocket.Advertise(Topic, "std_msgs/String");

            Message = new GeometryPoint();
     
        }

        public void btn_rightPressed()
        {
            current_voxelSize = (float)System.Math.Round(current_voxelSize + 0.005f,3);
            voxelValue.text = current_voxelSize.ToString();
            Message.x = current_voxelSize;

            rosSocket.Publish(publicationId, Message);

        }

        public void btn_leftPressed()
        {
            if (current_voxelSize < 0)
            {
                current_voxelSize = 0.005f;
            }

            else
            {
                current_voxelSize = (float)System.Math.Round(current_voxelSize - 0.005f,3);
                voxelValue.text = current_voxelSize.ToString();
                // Debug.Log("left button pressed");

                Message.x = current_voxelSize;
                rosSocket.Publish(publicationId, Message);

            }

        }

        public void btn_rightPressed_radius()
        {
            current_radiusLimit = (float)System.Math.Round(current_radiusLimit + 0.005f, 3);
            radiusValue.text = current_radiusLimit.ToString();
            Message.x = current_radiusLimit;

            rosSocket.Publish(publicationId2, Message);

        }

        public void btn_leftPressed_radius()
        {
            if (current_radiusLimit < 0)
            {
                current_radiusLimit = 0.005f;
            }

            else
            {
                current_radiusLimit = (float)System.Math.Round(current_radiusLimit - 0.005f, 3);
                radiusValue.text = current_radiusLimit.ToString();
                // Debug.Log("left button pressed");

                Message.x = current_radiusLimit;
                rosSocket.Publish(publicationId2, Message);

            }

        }

    }
}