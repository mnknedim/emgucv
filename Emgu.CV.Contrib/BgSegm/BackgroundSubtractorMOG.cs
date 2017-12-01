﻿//----------------------------------------------------------------------------
//  Copyright (C) 2004-2017 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;

namespace Emgu.CV.BgSegm
{
    /// <summary>
    /// Gaussian Mixture-based Background/Foreground Segmentation Algorithm.
    /// The class implements the following algorithm:
    /// "An improved adaptive background mixture model for real-time tracking with shadow detection"
    /// P. KadewTraKuPong and R. Bowden,
    /// Proc. 2nd European Workshp on Advanced Video-Based Surveillance Systems, 2001."
    /// http://personal.ee.surrey.ac.uk/Personal/R.Bowden/publications/avbs01/avbs01.pdf
    /// </summary>
    public class BackgroundSubtractorMOG : UnmanagedObject, IBackgroundSubtractor
    {


        private IntPtr _algorithmPtr;
        private IntPtr _backgroundSubtractorPtr;
        public IntPtr AlgorithmPtr { get { return _algorithmPtr; } }
        public IntPtr BackgroundSubtractorPtr { get { return _backgroundSubtractorPtr; } }

        /// <summary>
        /// Create an "Improved adaptive Gaussian mixture model for background subtraction".
        /// </summary>
        /// <param name="history">The length of the history.</param>
        /// <param name="nMixtures">The maximum number of gaussian mixtures.</param>
        /// <param name="backgroundRatio">Background ratio</param>
        /// <param name="noiseSigma">Noise strength (standard deviation of the brightness or each color channel). 0 means some automatic value.</param>
        public BackgroundSubtractorMOG(int history = 200, int nMixtures = 5, double backgroundRatio = 0.7,
         double noiseSigma = 0)
        {
            _ptr = ContribInvoke.CvBackgroundSubtractorMOGCreate(history, nMixtures, backgroundRatio, noiseSigma, ref _backgroundSubtractorPtr, ref _algorithmPtr);
        }

        /// <summary>
        /// Release all the unmanaged memory associated with this background model.
        /// </summary>
        protected override void DisposeObject()
        {
            if (IntPtr.Zero != _ptr)
            {
                ContribInvoke.CvBackgroundSubtractorMOGRelease(ref _ptr);
                _backgroundSubtractorPtr = IntPtr.Zero;
                _algorithmPtr = IntPtr.Zero;
            }
        }
    }
}

namespace Emgu.CV
{
    public static partial class ContribInvoke
    {
        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
        internal static extern IntPtr CvBackgroundSubtractorMOGCreate(int history, int nmixtures, double backgroundRatio, double noiseSigma, ref IntPtr bgSubtractor, ref IntPtr algorithm);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
        internal static extern void CvBackgroundSubtractorMOGRelease(ref IntPtr bgSubstractor);
    }
}
