using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MixerVoiceFormsDemo
{
    public class PCMHeader
    {
        /// <summary>
        /// 生成Wav Header
        /// </summary>
        /// <param name="totalDataLen">how big is the rest of this file?</param>
        /// <param name="channels">mono or stereo? 1 or 2?</param>
        /// <param name="longSampleRate">samples per second (numbers per second)</param>
        /// <param name="byteRate">bytes per second</param>
        /// <param name="RECORDER_BPP">how many bits in a sample(number)?</param>
        /// <param name="totalAudioLen">how big is this data chunk</param>
        /// <returns></returns>
        public byte[] GeneratePCMHeader(int totalDataLen, int channels, int longSampleRate, int byteRate, int RECORDER_BPP, int totalAudioLen)
        {
            byte[] header = new byte[44];

            header[0] = (byte)'R';  // RIFF/WAVE header             // 00 - RIFF
            header[1] = (byte)'I';
            header[2] = (byte)'F';
            header[3] = (byte)'F';
            header[4] = (byte)(totalDataLen & 0xff);                // 04 - how big is the rest of this file?
            header[5] = (byte)((totalDataLen >> 8) & 0xff);
            header[6] = (byte)((totalDataLen >> 16) & 0xff);
            header[7] = (byte)((totalDataLen >> 24) & 0xff);
            header[8] = (byte)'W';                                  // 08 - WAVE
            header[9] = (byte)'A';
            header[10] = (byte)'V';
            header[11] = (byte)'E';
            header[12] = (byte)'f';                                 // 'fmt ' chunk// 12 - fmt 
            header[13] = (byte)'m';
            header[14] = (byte)'t';
            header[15] = (byte)' ';
            header[16] = 16;  // 4 bytes: size of 'fmt ' chunk      // 16 - size of this chunk
            header[17] = 0;
            header[18] = 0;
            header[19] = 0;
            header[20] = 1;  // format = 1                          //20 - what is the audio format? 1 for PCM = Pulse Code Modulation
            header[21] = 0;
            header[22] = (byte)channels;                            // 22 - mono or stereo? 1 or 2?  (or 5 or ???)
            header[23] = 0;
            header[24] = (byte)(longSampleRate & 0xff);             // 24 - samples per second (numbers per second)
            header[25] = (byte)((longSampleRate >> 8) & 0xff);
            header[26] = (byte)((longSampleRate >> 16) & 0xff);
            header[27] = (byte)((longSampleRate >> 24) & 0xff);
            header[28] = (byte)(byteRate & 0xff);                   // 28 - bytes per second
            header[29] = (byte)((byteRate >> 8) & 0xff);
            header[30] = (byte)((byteRate >> 16) & 0xff);
            header[31] = (byte)((byteRate >> 24) & 0xff);
            header[32] = (byte)(2 * 16 / 8);  // block align        // 32 - # of bytes in one sample, for all channels
            header[33] = 0;
            header[34] = (byte)RECORDER_BPP;  // bits per sample    // 34 - how many bits in a sample(number)?  usually 16 or 24
            header[35] = 0;
            header[36] = (byte)'d';// 36 - data
            header[37] = (byte)'a';
            header[38] = (byte)'t';
            header[39] = (byte)'a';
            header[40] = (byte)(totalAudioLen & 0xff);              // 40 - how big is this data chunk
            header[41] = (byte)((totalAudioLen >> 8) & 0xff);
            header[42] = (byte)((totalAudioLen >> 16) & 0xff);
            header[43] = (byte)((totalAudioLen >> 24) & 0xff);

            return header;
        }

    }
}
