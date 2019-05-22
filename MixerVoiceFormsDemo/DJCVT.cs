using System;
using System.Collections.Generic;
using System.Text;

namespace DJCVT
{
    public partial class NativeConstants
    {

        /// _DJCVT_H_ -> 
        /// Error generating expression: 值不能为空。
        ///参数名: node
        public const string _DJCVT_H_ = "";
    }

    public partial class NativeMethods
    {

        /// Return Type: int
        ///PcmFileName: char*
        ///WaveFileName: char*
        [System.Runtime.InteropServices.DllImportAttribute("DJCVT.dll", EntryPoint = "PcmtoWave")]
        public static extern int PcmtoWave(System.IntPtr PcmFileName, System.IntPtr WaveFileName);


        /// Return Type: int
        ///WaveFileName: char*
        ///PcmFileName: char*
        [System.Runtime.InteropServices.DllImportAttribute("DJCVT.dll", EntryPoint = "WavetoPcm")]
        public static extern int WavetoPcm(System.IntPtr WaveFileName, System.IntPtr PcmFileName);


        /// Return Type: int
        ///AdpcmFileName: char*
        ///PcmFileName: char*
        [System.Runtime.InteropServices.DllImportAttribute("DJCVT.dll", EntryPoint = "AdtoPcm")]
        public static extern int AdtoPcm(System.IntPtr AdpcmFileName, System.IntPtr PcmFileName);


        /// Return Type: int
        ///PcmFileName: char*
        ///AdpcmFileName: char*
        [System.Runtime.InteropServices.DllImportAttribute("DJCVT.dll", EntryPoint = "PcmtoAd")]
        public static extern int PcmtoAd(System.IntPtr PcmFileName, System.IntPtr AdpcmFileName);


        /// Return Type: int
        ///AdpcmFileName: char*
        ///PcmFileName: char*
        [System.Runtime.InteropServices.DllImportAttribute("DJCVT.dll", EntryPoint = "Ad6ktoPcm")]
        public static extern int Ad6ktoPcm(System.IntPtr AdpcmFileName, System.IntPtr PcmFileName);


        /// Return Type: int
        ///PcmFileName: char*
        ///WaveFileName: char*
        ///WaveFormat: int
        [System.Runtime.InteropServices.DllImportAttribute("DJCVT.dll", EntryPoint = "PcmtoWaveNew")]
        public static extern int PcmtoWaveNew(System.IntPtr PcmFileName, System.IntPtr WaveFileName, int WaveFormat);


        /// Return Type: int
        ///PcmMemory: char*
        ///WaveMemory: char*
        ///SizeofSrc: int
        [System.Runtime.InteropServices.DllImportAttribute("DJCVT.dll", EntryPoint = "PcmMtoWaveM")]
        public static extern int PcmMtoWaveM(System.IntPtr PcmMemory, System.IntPtr WaveMemory, int SizeofSrc);

    }

}
