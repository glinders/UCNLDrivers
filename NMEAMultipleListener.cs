﻿using System;
using System.Collections.Generic;
using System.Text;
using UCNLNMEA;

namespace UCNLDrivers
{
    #region Custom items

    public struct SatelliteData
    {
        #region Properties

        public int PRNNumber;
        public int Elevation;
        public int Azimuth;
        public int SNR;

        #endregion

        #region Constructor

        public SatelliteData(int prn, int elevation, int azimuth, int snr)
        {
            PRNNumber = prn;
            Elevation = elevation;
            Azimuth = azimuth;
            SNR = snr;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return string.Format("PRN: {0:00}, Elevation: {1:00}°, Azimuth: {2:000}°, SNR: {3:00} dB", PRNNumber, Elevation, Azimuth, SNR);
        }

        #endregion
    }

    #endregion

    #region Custom EventArgs

    public class InfoEventArgs : EventArgs
    {
        #region Properties

        public string Message { get; private set; }

        #endregion

        #region Constructor

        public InfoEventArgs(string message)
        {
            Message = message;
        }

        #endregion
    }

    public class NMEAMessageEventArgs : EventArgs
    {
        #region Properties

        public int SourceID { get; private set; }
        public string Message { get; private set; }

        #endregion

        #region Contructor

        public NMEAMessageEventArgs(int sourceID, string message)
        {
            SourceID = sourceID;
            Message = message;
        }

        #endregion
    }

    public class NMEAUnsupportedStandartEventArgs : EventArgs
    {
        #region Properties

        public int SourceID { get; private set; }
        public NMEAStandartSentence Sentence { get; private set; }

        #endregion

        #region Contructor

        public NMEAUnsupportedStandartEventArgs(int sourceID, NMEAStandartSentence sentence)
        {
            SourceID = sourceID;
            Sentence = sentence;
        }

        #endregion
    }

    public class NMEAUnsupportedProprietaryEventArgs : EventArgs
    {
        #region Properties

        public int SourceID { get; private set; }
        public NMEAProprietarySentence Sentence { get; private set; }

        #endregion

        #region Contructor

        public NMEAUnsupportedProprietaryEventArgs(int sourceID, NMEAProprietarySentence sentence)
        {
            SourceID = sourceID;
            Sentence = sentence;
        }

        #endregion
    }


    public class RMCMessageEventArgs : EventArgs
    {
        #region Properties

        public int SourceID { get; private set; }
        public TalkerIdentifiers TalkerID { get; private set; }
        public DateTime TimeFix { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public double SpeedKmh { get; private set; }
        public double TrackTrue { get; private set; }
        public double MagneticVariation { get; private set; }
        public bool IsValid { get; private set; }       

        #endregion

        #region Constructor

        public RMCMessageEventArgs(int sourceID, TalkerIdentifiers talkerID, DateTime timeFix, double lat, double lon, double speedKmh, double trackTrue, double mVar, bool isValid)
        {
            SourceID = sourceID;
            TalkerID = talkerID;
            TimeFix = timeFix;
            Latitude = lat;
            Longitude = lon;
            SpeedKmh = speedKmh;
            TrackTrue = trackTrue;
            MagneticVariation = mVar;
            IsValid = isValid;
        }

        #endregion
    }

    public class VTGMessageEventArgs : EventArgs
    {
        #region Properties

        public int SourceID { get; private set; }
        public TalkerIdentifiers TalkerID { get; private set; }
        public double TrackTrue { get; private set; }
        public double TrackMagnetic { get; private set; }
        public double SpeedKmh { get; private set; }
        public bool IsValid { get; private set; }

        #endregion

        #region Constructor

        public VTGMessageEventArgs(int sourceID, TalkerIdentifiers talkerID, double trackTrue, double trackMagnetic, double speedKmh, bool isValid)
        {
            SourceID = sourceID;
            TalkerID = talkerID;
            TrackTrue = trackTrue;
            TrackMagnetic = TrackMagnetic;
            SpeedKmh = speedKmh;
            IsValid = isValid;
        }

        #endregion

    }

    public class HDGMessageEventArgs : EventArgs
    {
        #region Properties

        public int SourceID { get; private set; }             
        public TalkerIdentifiers TalkerID { get; private set; }
        public double MagneticHeading { get; private set; }
        public double MagneticVariation { get; private set; }
        public bool IsValid { get; private set; }

        #endregion

        #region Constructor

        public HDGMessageEventArgs(int sourceID, TalkerIdentifiers talkerID, double mHeading, double mVariation, bool isValid)
        {
            SourceID = sourceID;
            TalkerID = talkerID;
            MagneticHeading = mHeading;
            MagneticVariation = mVariation;
            IsValid = isValid;
        }


        #endregion
    }

    public class HDTMessageEventArgs : EventArgs
    {
        // $GPHDT,253.423,T*34

        #region Properties

        public int SourceID { get; private set; }
        public TalkerIdentifiers TalkerID { get; private set; }
        public double Heading { get; private set; }        
        public bool IsValid { get; private set; }

        #endregion

        #region Constructor

        public HDTMessageEventArgs(int sourceID, TalkerIdentifiers talkerID, double heading, bool isValid)
        {
            SourceID = sourceID;
            TalkerID = talkerID;
            Heading = heading;            
            IsValid = isValid;
        }


        #endregion
    }

    public class GGAMessageEventArgs : EventArgs
    {
        #region Properties

        public int SourceID { get; private set; }
        public TalkerIdentifiers TalkerID { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public string GNSSQualityIndicator { get; private set; }
        public int SatellitesInUse { get; private set; }
        public double HDOP { get; private set; }
        public double OrthometricHeight { get; private set; } 
                // orthometric height units parameters[9]
        public double GeiodSeparation { get; private set; }
                // geoid separation units parameters[11]
        public int DGPSRecordAge { get; private set; }
        public int DatumID { get; private set; }
        public bool IsValid { get; private set; }

        #endregion

        #region Constructor

        public GGAMessageEventArgs(int sourceID, TalkerIdentifiers talkerID, DateTime timeStamp, 
            double lat, double lon, string gnssQuality, int satNum, double hdop, double orHeight, double gSep, int dgpsAge, int datumID, bool isValid)
        {
            SourceID = sourceID;
            TalkerID = talkerID;
            TimeStamp = timeStamp;
            Latitude = lat;
            Longitude = lon;
            GNSSQualityIndicator = gnssQuality;
            SatellitesInUse = satNum;
            HDOP = hdop;
            OrthometricHeight = orHeight;
            GeiodSeparation = gSep;
            DGPSRecordAge = dgpsAge;
            DatumID = datumID;
            IsValid = isValid;           
        }

        #endregion
    }

    public class GSVMessageEventArgs : EventArgs
    {
        #region Properties

        public int SourceID { get; private set; }
        public TalkerIdentifiers TalkerID { get; private set; }
        public SatelliteData[] SatellitesData { get; private set; }

        #endregion

        #region Constructor

        public GSVMessageEventArgs(int sourceID, TalkerIdentifiers taklerID, SatelliteData[] satsData)
        {
            SourceID = sourceID;
            TalkerID = taklerID;
            SatellitesData = satsData;
        }

        #endregion
    }

    public class GLLMessageEventArgs : EventArgs
    {
        #region Properties

        public int SourceID { get; private set; }
        public TalkerIdentifiers TalkerID { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public bool IsValid { get; private set; }

        #endregion

        #region Constructor

        public GLLMessageEventArgs(int sourceID, TalkerIdentifiers talkerID, double latitude, double longitude, DateTime tStamp, bool isValid)
        {
            SourceID = sourceID;
            TalkerID = talkerID;
            Latitude = latitude;
            Longitude = longitude;
            TimeStamp = tStamp;
            IsValid = isValid;
        }

        #endregion
    }

    public class GSAMessageEventArgs : EventArgs
    {
        #region Properties

        public int SourceID { get; private set; }
        public TalkerIdentifiers TalkerID { get; private set; }    
        public string FixSelection { get; private set; }
        public string FixType { get; private set; }
        public int[] UsedSatellitesIDs { get; private set; }
        public double PDOP { get; private set; }
        public double HDOP { get; private set; }
        public double VDOP { get; private set; }
        public bool IsValid { get; private set; }

        #endregion

        #region Constructor         

        public GSAMessageEventArgs(int sourceID, TalkerIdentifiers talkerID, string fSelection, string fType, List<int> satIDs, double pDOP, double hDOP, double vDOP, bool isValid)
        {
            SourceID = sourceID;
            TalkerID = talkerID;
            FixSelection = fSelection;
            FixType = fType;
            UsedSatellitesIDs = satIDs.ToArray();
            PDOP = pDOP;
            HDOP = hDOP;
            VDOP = vDOP;
            IsValid = isValid;
        }

        #endregion

    }

    public class MTWMessageEventArgs : EventArgs
    {
        #region Properties

        public int SourceID { get; private set; }
        public TalkerIdentifiers TalkerID { get; private set; }
        public double MeanWaterTemperature { get; private set; }
        public bool IsValid { get; private set; }

        #endregion

        #region Constructor

        public MTWMessageEventArgs(int sourceID, TalkerIdentifiers talkerID, double temp, bool isValid)
        {
            SourceID = sourceID;
            TalkerID = talkerID;
            MeanWaterTemperature = temp;
            IsValid = isValid;
        }

        #endregion
    }

    #endregion
    
    public class NMEAMultipleListener
    {
        #region Properties

        Dictionary<int, StringBuilder> buffer;
        Dictionary<int, List<SatelliteData>> fullSatellitesData;

        private delegate void ProcessCommandDelegate(int sourceID, TalkerIdentifiers talkerID, object[] parameters);
        private Dictionary<SentenceIdentifiers, ProcessCommandDelegate> standardSenteceParsers;

        delegate T NullChecker<T>(object parameter);
        NullChecker<int> intNullChecker = (x => x == null ? -1 : (int)x);
        NullChecker<double> doubleNullChecker = (x => x == null ? double.NaN : (double)x);
        NullChecker<string> stringNullChecker = (x => x == null ? string.Empty : (string)x);
               
        #endregion

        #region Constructor

        public NMEAMultipleListener()
        {
            #region buffer

            buffer = new Dictionary<int, StringBuilder>();
            fullSatellitesData = new Dictionary<int,List<SatelliteData>>();

            #endregion
            
            #region parsers initialization

            standardSenteceParsers = new Dictionary<SentenceIdentifiers, ProcessCommandDelegate>()
            {
                // GNSS receivers
                { SentenceIdentifiers.GGA, new ProcessCommandDelegate(OnGGASentence) },
                { SentenceIdentifiers.GSV, new ProcessCommandDelegate(OnGSVSentence) },
                { SentenceIdentifiers.GLL, new ProcessCommandDelegate(OnGLLSentence) },
                { SentenceIdentifiers.RMC, new ProcessCommandDelegate(OnRMCSentence) },
                { SentenceIdentifiers.VTG, new ProcessCommandDelegate(OnVTGSentence) },
                { SentenceIdentifiers.GSA, new ProcessCommandDelegate(OnGSASentence) },                

                // Magnetic compass
                { SentenceIdentifiers.HDG, new ProcessCommandDelegate(OnHDGSentence) },
                { SentenceIdentifiers.HDT, new ProcessCommandDelegate(OnHDTSentence) },

                // Custom marine equipment
                { SentenceIdentifiers.MTW, new ProcessCommandDelegate(OnMTWSentence) },
            };

            #endregion
        }

        #endregion

        #region Methods

        #region Public

        public void ProcessIncoming(int sourceID, string data)
        {
            if (!buffer.ContainsKey(sourceID))
                buffer.Add(sourceID, new StringBuilder());

            buffer[sourceID].Append(data);
            var temp = buffer[sourceID].ToString();

            int lIndex = temp.LastIndexOf(NMEAParser.SentenceEndDelimiter);
            if (lIndex >= 0)
            {
                buffer[sourceID].Remove(0, lIndex + 2);
                if (lIndex + 2 < temp.Length)
                    temp = temp.Remove(lIndex + 2);

                temp = temp.Trim(new char[] { '\0' });

                int startIdx = temp.IndexOf(NMEAParser.SentenceStartDelimiter);
                if (startIdx > 0)
                    temp = temp.Remove(0, startIdx);

                var lines = temp.Split(NMEAParser.SentenceEndDelimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
              
                for (int i = 0; i < lines.Length; i++)
                        Parse(sourceID, string.Format("{0}{1}", lines[i], NMEAParser.SentenceEndDelimiter));                
            }

            if (buffer[sourceID].Length >= ushort.MaxValue)
                buffer[sourceID].Remove(0, short.MaxValue);
        }        

        #endregion

        #region Private

        #region Standard sentence parsers

        private void OnGGASentence(int sourceID, TalkerIdentifiers talkerID, object[] parameters)
        {
            if (GGASentenceReceived != null)
            {
                DateTime tStamp = (DateTime)parameters[0];

                double latitude = doubleNullChecker(parameters[1]);
                double longitude = doubleNullChecker(parameters[3]);

                string gnssQualityIndicator = parameters[5].ToString();
                int satellitesInUse = intNullChecker(parameters[6]);
                double HDOP = doubleNullChecker(parameters[7]);
                double orthometricHeight = doubleNullChecker(parameters[8]);
                // orthometric height units parameters[9]
                double geiodSeparation = doubleNullChecker(parameters[10]);
                // geoid separation units parameters[11]
                int DGPSRecordAge = intNullChecker(parameters[12]);
                int datumID = intNullChecker(parameters[13]);

                bool isValid = (!double.IsNaN(latitude)) &&
                               (!double.IsNaN(longitude)) &&
                               (!double.IsNaN(HDOP));


                if (isValid)
                {                    
                    if (parameters[2].ToString() == "South") latitude = -latitude;
                    if (parameters[4].ToString() == "West") longitude = -longitude;
                }

                GGASentenceReceived(this, new GGAMessageEventArgs(sourceID, talkerID, tStamp, 
                    latitude, longitude, gnssQualityIndicator, satellitesInUse, HDOP, orthometricHeight, geiodSeparation, DGPSRecordAge, datumID, isValid));
            }            
        }

        private void OnGSVSentence(int sourceID, TalkerIdentifiers talkerID, object[] parameters)
        {
            if (GSVSentenceReceived != null)
            {               
                List<SatelliteData> satellites = new List<SatelliteData>();

                int totalMessages = (int)parameters[0];
                int currentMessageNumber = (int)parameters[1];

                int satellitesDataItemsCount = (parameters.Length - 3) / 4;

                for (int i = 0; i < satellitesDataItemsCount; i++)
                {
                    satellites.Add(
                        new SatelliteData(
                            intNullChecker(parameters[3 + 4 * i]),
                            intNullChecker(parameters[4 + 4 * i]),
                            intNullChecker(parameters[5 + 4 * i]),
                            intNullChecker(parameters[6 + 4 * i])));
                }

                if (!fullSatellitesData.ContainsKey(sourceID))
                    fullSatellitesData.Add(sourceID, new List<SatelliteData>());

                if (currentMessageNumber == 1)
                    fullSatellitesData[sourceID] = new List<SatelliteData>();

                fullSatellitesData[sourceID].AddRange(satellites.ToArray());

                if (currentMessageNumber == totalMessages)
                    GSVSentenceReceived(this, new GSVMessageEventArgs(sourceID, talkerID, fullSatellitesData[sourceID].ToArray()));
            }
        }

        private void OnGLLSentence(int sourceID, TalkerIdentifiers talkerID, object[] parameters)
        {
            if (GLLSentenceReceived != null)
            {
                double latitude = doubleNullChecker(parameters[0]);
                double longitude = doubleNullChecker(parameters[2]);
                DateTime tStamp = (DateTime)parameters[4];
                bool isValid = (parameters[5].ToString() == "Valid") &&
                               (!double.IsNaN(latitude)) &&
                               (!double.IsNaN(longitude));

                if (isValid)
                {                  
                    if (parameters[1].ToString() == "South") latitude = -latitude;
                    if (parameters[3].ToString() == "West") longitude = -longitude;
                }

                GLLSentenceReceived(this, new GLLMessageEventArgs(sourceID, talkerID, latitude, longitude, tStamp, isValid));
            }
        }

        private void OnRMCSentence(int sourceID, TalkerIdentifiers talkerID, object[] parameters)
        {           
            if (RMCSentenceReceived != null)
            {
                DateTime tStamp = (DateTime)parameters[0];

                var latitude = doubleNullChecker(parameters[2]);
                var longitude = doubleNullChecker(parameters[4]);
                var groundSpeed = doubleNullChecker(parameters[6]);
                var courseOverGround = doubleNullChecker(parameters[7]);
                var dateTime = (DateTime)parameters[8];
                var magneticVariation = doubleNullChecker(parameters[9]);

                bool isValid = (parameters[1].ToString() != "Invalid") &&
                               (!double.IsNaN(latitude)) &&
                               (!double.IsNaN(longitude)) &&
                               (!double.IsNaN(groundSpeed)) &&
                               (!double.IsNaN(courseOverGround)) &&
                               (parameters[11].ToString() != "N");

                if (isValid)
                {
                    dateTime.AddHours(tStamp.Hour);
                    dateTime.AddMinutes(tStamp.Minute);
                    dateTime.AddSeconds(tStamp.Second);
                    dateTime.AddMilliseconds(tStamp.Millisecond);
                    groundSpeed = NMEAParser.NM2Km(groundSpeed);

                    if (parameters[3].ToString() == "South") latitude = -latitude;
                    if (parameters[5].ToString() == "West") longitude = -longitude;
                }

                RMCSentenceReceived(this, new RMCMessageEventArgs(sourceID, talkerID, dateTime, latitude, longitude, groundSpeed, courseOverGround, magneticVariation, isValid));
            }
        }

        private void OnVTGSentence(int sourceID, TalkerIdentifiers talkerID, object[] parameters)
        {
            if (VTGSentenceReceived != null)
            {
                var trackTrue = doubleNullChecker(parameters[0]);
                var trackMagnetic = doubleNullChecker(parameters[2]);
                var speedKnots = doubleNullChecker(parameters[4]);
                var skUnits = (string)parameters[5];
                var speedKmh = doubleNullChecker(parameters[6]);
                var sKmUnits = (string)parameters[7];

                bool isValid = (!double.IsNaN(trackTrue) || !double.IsNaN(trackMagnetic)) &&
                               !double.IsNaN(speedKnots) &&
                               !double.IsNaN(speedKmh);


                VTGSentenceReceived(this, new VTGMessageEventArgs(sourceID, talkerID, trackTrue, trackMagnetic, speedKmh, isValid));
            }
        }

        private void OnGSASentence(int sourceID, TalkerIdentifiers talkerID, object[] parameters)
        {
            if (GSASentenceReceived != null)
            {                
                string fixSelection = parameters[0].ToString();
                string fixType = parameters[1].ToString();

                List<int> satIDs = new List<int>();

                for (int i = 2; i < 14; i++)
                {
                    int tPRN = intNullChecker(parameters[i]);
                    if (tPRN >= 0) satIDs.Add(tPRN);
                }

                double PDOP = doubleNullChecker(parameters[14]);
                double HDOP = doubleNullChecker(parameters[15]);
                double VDOP = doubleNullChecker(parameters[16]);

                bool isValid = (satIDs.Count > 0) && (!double.IsNaN(PDOP)) && (!double.IsNaN(HDOP)) && (!double.IsNaN(VDOP));

                GSASentenceReceived(this, new GSAMessageEventArgs(sourceID, talkerID, fixSelection, fixType, satIDs, PDOP, HDOP, VDOP, isValid));
            }
        }

        private void OnHDGSentence(int sourceID, TalkerIdentifiers talkerID, object[] parameters)
        {           
            if (HDGSentenceReceived != null)
            {
                double magneticHeading = doubleNullChecker(parameters[0]);
                double magneticVariation = doubleNullChecker(parameters[3]);
                if (double.IsNaN(magneticVariation)) magneticVariation = 0.0;

                bool isValid = !double.IsNaN(magneticHeading);

                HDGSentenceReceived(this, new HDGMessageEventArgs(sourceID, talkerID, magneticHeading, magneticVariation, isValid));
            }
        }

        private void OnHDTSentence(int sourceID, TalkerIdentifiers talkerID, object[] parameters)
        {
            // $GPHDT,253.423,T*34
            if (HDTSentenceReceived != null)
            {
                double heading = doubleNullChecker(parameters[0]);
                bool isValid = !double.IsNaN(heading);

                HDTSentenceReceived(this, new HDTMessageEventArgs(sourceID, talkerID, heading, isValid));    
            }
        }

        private void OnMTWSentence(int sourceID, TalkerIdentifiers talkerID, object[] parameters)
        {
            if (MTWSentenceReceived != null)
            {
                double temp = doubleNullChecker(parameters[0]);
                bool isValid = !double.IsNaN(temp);
                MTWSentenceReceived(this, new MTWMessageEventArgs(sourceID, talkerID, temp, isValid));
            }
        }

        #endregion

        private void Parse(int sourceID, string message)
        {            
            if (NMEAIncomingMessageReceived != null)
                NMEAIncomingMessageReceived(this, new NMEAMessageEventArgs(sourceID, message));

            try
            {
                var pResult = NMEAParser.Parse(message);

                if (pResult is NMEAStandartSentence)
                {
                    NMEAStandartSentence sentence = (NMEAStandartSentence)pResult;
                    if (standardSenteceParsers.ContainsKey(sentence.SentenceID))
                        standardSenteceParsers[sentence.SentenceID](sourceID, sentence.TalkerID, sentence.parameters);
                    else
                    {                        
                        if (NMEAStandartUnsupportedSentenceParsed != null)
                            NMEAStandartUnsupportedSentenceParsed(this, new NMEAUnsupportedStandartEventArgs(sourceID, sentence));
                    }
                }
                else
                {
                    if (NMEAProprietaryUnsupportedSentenceParsed != null)
                        NMEAProprietaryUnsupportedSentenceParsed(this, new NMEAUnsupportedProprietaryEventArgs(sourceID, (pResult as NMEAProprietarySentence)));
                }

            }
            catch (Exception ex)
            {
                if (InfoEvent != null)
                    InfoEvent(this, new InfoEventArgs(string.Format("Exception {0}, TargetSite: {1}", ex.Message, ex.TargetSite)));
            }
        }

        #endregion

        #endregion

        #region Events

        public EventHandler<NMEAUnsupportedStandartEventArgs> NMEAStandartUnsupportedSentenceParsed;
        public EventHandler<NMEAUnsupportedProprietaryEventArgs> NMEAProprietaryUnsupportedSentenceParsed;
        public EventHandler<NMEAMessageEventArgs> NMEAIncomingMessageReceived;        

        public EventHandler<HDGMessageEventArgs> HDGSentenceReceived;
        public EventHandler<HDTMessageEventArgs> HDTSentenceReceived;
        public EventHandler<RMCMessageEventArgs> RMCSentenceReceived;
        public EventHandler<VTGMessageEventArgs> VTGSentenceReceived;
        public EventHandler<GGAMessageEventArgs> GGASentenceReceived;
        public EventHandler<GSVMessageEventArgs> GSVSentenceReceived;
        public EventHandler<GLLMessageEventArgs> GLLSentenceReceived;
        public EventHandler<GSAMessageEventArgs> GSASentenceReceived;
        public EventHandler<MTWMessageEventArgs> MTWSentenceReceived;

        public EventHandler<InfoEventArgs> InfoEvent;

        #endregion        
    }
}
