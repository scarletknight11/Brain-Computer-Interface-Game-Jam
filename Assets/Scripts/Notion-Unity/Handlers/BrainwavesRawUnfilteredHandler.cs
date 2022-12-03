﻿using Newtonsoft.Json;
using System.Text;
using System;
using System.Linq;
using UnityEngine;

namespace Notion.Unity
{
    public class BrainwavesRawUnfilteredHandler : IMetricHandler
    {
        public Metrics Metric => Metrics.Brainwaves;
        public string Label => "rawUnfiltered";

        public Action<Epoch> OnBrainwavesRawUnfilteredUpdated { get; set; }

        private readonly StringBuilder _builder;

        public BrainwavesRawUnfilteredHandler()
        {
            _builder = new StringBuilder();
        }

        public void Handle(string metricData)
        {
            Epoch epoch = JsonConvert.DeserializeObject<Epoch>(metricData);

            OnBrainwavesRawUnfilteredUpdated?.Invoke(epoch);

            _builder.AppendLine("Handling Raw Unfiltered Brainwaves")
                .Append("Label: ").AppendLine(epoch.Label)
                .Append("Notch Frequency: ").AppendLine(epoch.Info.NotchFrequency)
                .Append("Sampling Rate: ").AppendLine(epoch.Info.SamplingRate.ToString())
                .Append("Star Time: ").AppendLine(epoch.Info.StartTime.ToString())
                .Append("Channel Names: ").AppendLine(string.Join(", ", epoch.Info.ChannelNames));

            //Debug.Log(_builder.ToString());
            _builder.Clear();
        }
    }
}