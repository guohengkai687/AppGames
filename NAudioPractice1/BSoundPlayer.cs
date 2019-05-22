using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio.Wave;

namespace NAudioPractice1
{
    public class BSoundPlayer
    {
        private IWavePlayer wavePlayer;
        private AudioFileReader audioFileReader;

        public string FileName = "";

        private bool isPlaying = false;
        public bool IsPlaying
        {
            get { return isPlaying; }
        }

        public TimeSpan CurrentTime
        {
            get
            {
                if (audioFileReader == null)
                {
                    return TimeSpan.Zero;
                }
                else
                {
                    return audioFileReader.CurrentTime;
                }
            }
        }

        public TimeSpan TotalTime
        {
            get
            {
                if (audioFileReader == null)
                {
                    return TimeSpan.Zero;
                }
                else
                {
                    return audioFileReader.TotalTime;
                }
            }
        }

        private float volume = 1f;
        public float Volume
        {
            get { return volume; }
            set
            {
                if (value >= 0 && value <= 1f)
                {
                    volume = value;
                    if (audioFileReader != null)
                    {
                        audioFileReader.Volume = value;
                    }
                }
            }
        }

        public BSoundPlayer()
        {

        }

        public void Play()
        {
            if (string.IsNullOrEmpty(FileName))
            {
                return;
            }

            if (isPlaying)
            {
                return;
            }

            wavePlayer = new WaveOut();
            audioFileReader = new AudioFileReader(FileName);
            audioFileReader.Volume = volume;
            wavePlayer.Init(audioFileReader);
            wavePlayer.PlaybackStopped += OnPlaybackStopped;
            wavePlayer.Play();
            isPlaying = true;
        }

        public void Stop()
        {
            if (wavePlayer != null)
            {
                wavePlayer.Stop();
            }
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }
            if (wavePlayer != null)
            {
                wavePlayer.Dispose();
                wavePlayer = null;
            }

            isPlaying = false;
        }
    }
}
