/**
 * Copyright (c) 2017 Enzien Audio, Ltd.
 * 
 * Redistribution and use in source and binary forms, with or without modification,
 * are permitted provided that the following conditions are met:
 * 
 * 1. Redistributions of source code must retain the above copyright notice,
 *    this list of conditions, and the following disclaimer.
 * 
 * 2. Redistributions in binary form must reproduce the phrase "powered by heavy",
 *    the heavy logo, and a hyperlink to https://enzienaudio.com, all in a visible
 *    form.
 * 
 *   2.1 If the Application is distributed in a store system (for example,
 *       the Apple "App Store" or "Google Play"), the phrase "powered by heavy"
 *       shall be included in the app description or the copyright text as well as
 *       the in the app itself. The heavy logo will shall be visible in the app
 *       itself as well.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO,
 * THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
 * FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
 * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
 * CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
 * OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
 * THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 * 
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Assertions;
using AOT;

#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(Hv_musicObject_AudioLib))]
public class Hv_musicObject_Editor : Editor {

  [MenuItem("Heavy/musicObject")]
  static void CreateHv_musicObject() {
    GameObject target = Selection.activeGameObject;
    if (target != null) {
      target.AddComponent<Hv_musicObject_AudioLib>();
    }
  }
  
  private Hv_musicObject_AudioLib _dsp;

  private void OnEnable() {
    _dsp = target as Hv_musicObject_AudioLib;
  }

  public override void OnInspectorGUI() {
    bool isEnabled = _dsp.IsInstantiated();
    if (!isEnabled) {
      EditorGUILayout.LabelField("Press Play!",  EditorStyles.centeredGreyMiniLabel);
    }
    // events
    GUI.enabled = isEnabled;
    EditorGUILayout.Space();
    // clockStart
    if (GUILayout.Button("clockStart")) {
      _dsp.SendEvent(Hv_musicObject_AudioLib.Event.Clockstart);
    }
    
    // kickActive
    if (GUILayout.Button("kickActive")) {
      _dsp.SendEvent(Hv_musicObject_AudioLib.Event.Kickactive);
    }
    
    // triggerDrone
    if (GUILayout.Button("triggerDrone")) {
      _dsp.SendEvent(Hv_musicObject_AudioLib.Event.Triggerdrone);
    }
    
    GUILayout.EndVertical();

    // parameters
    GUI.enabled = true;
    GUILayout.BeginVertical();
    EditorGUILayout.Space();
    EditorGUI.indentLevel++;
    
    // BPM
    GUILayout.BeginHorizontal();
    float BPM = _dsp.GetFloatParameter(Hv_musicObject_AudioLib.Parameter.Bpm);
    float newBpm = EditorGUILayout.Slider("BPM", BPM, 20.0f, 200.0f);
    if (BPM != newBpm) {
      _dsp.SetFloatParameter(Hv_musicObject_AudioLib.Parameter.Bpm, newBpm);
    }
    GUILayout.EndHorizontal();
    
    // droneBinPhase
    GUILayout.BeginHorizontal();
    float droneBinPhase = _dsp.GetFloatParameter(Hv_musicObject_AudioLib.Parameter.Dronebinphase);
    float newDronebinphase = EditorGUILayout.Slider("droneBinPhase", droneBinPhase, 0.0f, 20.0f);
    if (droneBinPhase != newDronebinphase) {
      _dsp.SetFloatParameter(Hv_musicObject_AudioLib.Parameter.Dronebinphase, newDronebinphase);
    }
    GUILayout.EndHorizontal();
    
    // droneChance
    GUILayout.BeginHorizontal();
    float droneChance = _dsp.GetFloatParameter(Hv_musicObject_AudioLib.Parameter.Dronechance);
    float newDronechance = EditorGUILayout.Slider("droneChance", droneChance, 0.0f, 100.0f);
    if (droneChance != newDronechance) {
      _dsp.SetFloatParameter(Hv_musicObject_AudioLib.Parameter.Dronechance, newDronechance);
    }
    GUILayout.EndHorizontal();
    
    // droneFmAmount
    GUILayout.BeginHorizontal();
    float droneFmAmount = _dsp.GetFloatParameter(Hv_musicObject_AudioLib.Parameter.Dronefmamount);
    float newDronefmamount = EditorGUILayout.Slider("droneFmAmount", droneFmAmount, 0.0f, 2000.0f);
    if (droneFmAmount != newDronefmamount) {
      _dsp.SetFloatParameter(Hv_musicObject_AudioLib.Parameter.Dronefmamount, newDronefmamount);
    }
    GUILayout.EndHorizontal();
    
    // droneFmFratio
    GUILayout.BeginHorizontal();
    float droneFmFratio = _dsp.GetFloatParameter(Hv_musicObject_AudioLib.Parameter.Dronefmfratio);
    float newDronefmfratio = EditorGUILayout.Slider("droneFmFratio", droneFmFratio, 0.1f, 4.0f);
    if (droneFmFratio != newDronefmfratio) {
      _dsp.SetFloatParameter(Hv_musicObject_AudioLib.Parameter.Dronefmfratio, newDronefmfratio);
    }
    GUILayout.EndHorizontal();
    
    // dronePitchRange
    GUILayout.BeginHorizontal();
    float dronePitchRange = _dsp.GetFloatParameter(Hv_musicObject_AudioLib.Parameter.Dronepitchrange);
    float newDronepitchrange = EditorGUILayout.Slider("dronePitchRange", dronePitchRange, 2.0f, 24.0f);
    if (dronePitchRange != newDronepitchrange) {
      _dsp.SetFloatParameter(Hv_musicObject_AudioLib.Parameter.Dronepitchrange, newDronepitchrange);
    }
    GUILayout.EndHorizontal();
    
    // jzChordOffset
    GUILayout.BeginHorizontal();
    float jzChordOffset = _dsp.GetFloatParameter(Hv_musicObject_AudioLib.Parameter.Jzchordoffset);
    float newJzchordoffset = EditorGUILayout.Slider("jzChordOffset", jzChordOffset, 0.0f, 48.0f);
    if (jzChordOffset != newJzchordoffset) {
      _dsp.SetFloatParameter(Hv_musicObject_AudioLib.Parameter.Jzchordoffset, newJzchordoffset);
    }
    GUILayout.EndHorizontal();
    
    // monoMelChance
    GUILayout.BeginHorizontal();
    float monoMelChance = _dsp.GetFloatParameter(Hv_musicObject_AudioLib.Parameter.Monomelchance);
    float newMonomelchance = EditorGUILayout.Slider("monoMelChance", monoMelChance, 0.0f, 100.0f);
    if (monoMelChance != newMonomelchance) {
      _dsp.SetFloatParameter(Hv_musicObject_AudioLib.Parameter.Monomelchance, newMonomelchance);
    }
    GUILayout.EndHorizontal();
    EditorGUI.indentLevel--;
  }
}
#endif // UNITY_EDITOR

[RequireComponent (typeof (AudioSource))]
public class Hv_musicObject_AudioLib : MonoBehaviour {
  
  // Events are used to trigger bangs in the patch context (thread-safe).
  // Example usage:
  /*
    void Start () {
        Hv_musicObject_AudioLib script = GetComponent<Hv_musicObject_AudioLib>();
        script.SendEvent(Hv_musicObject_AudioLib.Event.Clockstart);
    }
  */
  public enum Event : uint {
    Clockstart = 0x68AC5BDA,
    Kickactive = 0x4111BF22,
    Triggerdrone = 0xD5CDA205,
  }
  
  // Parameters are used to send float messages into the patch context (thread-safe).
  // Example usage:
  /*
    void Start () {
        Hv_musicObject_AudioLib script = GetComponent<Hv_musicObject_AudioLib>();
        // Get and set a parameter
        float BPM = script.GetFloatParameter(Hv_musicObject_AudioLib.Parameter.Bpm);
        script.SetFloatParameter(Hv_musicObject_AudioLib.Parameter.Bpm, BPM + 0.1f);
    }
  */
  public enum Parameter : uint {
    Bpm = 0x926A23B1,
    Dronebinphase = 0xD3AC4386,
    Dronechance = 0x6FC6740C,
    Dronefmamount = 0x259F7672,
    Dronefmfratio = 0x2E5EC306,
    Dronepitchrange = 0x62A09ED,
    Jzchordoffset = 0xF0B53968,
    Monomelchance = 0x578D5E97,
  }
  
  // Delegate method for receiving float messages from the patch context (thread-safe).
  // Example usage:
  /*
    void Start () {
        Hv_musicObject_AudioLib script = GetComponent<Hv_musicObject_AudioLib>();
        script.RegisterSendHook();
        script.FloatReceivedCallback += OnFloatMessage;
    }

    void OnFloatMessage(Hv_musicObject_AudioLib.FloatMessage message) {
        Debug.Log(message.receiverName + ": " + message.value);
    }
  */
  public class FloatMessage {
    public string receiverName;
    public float value;

    public FloatMessage(string name, float x) {
      receiverName = name;
      value = x;
    }
  }
  public delegate void FloatMessageReceived(FloatMessage message);
  public FloatMessageReceived FloatReceivedCallback;
  public float BPM = 120.0f;
  public float droneBinPhase = 6.0f;
  public float droneChance = 25.0f;
  public float droneFmAmount = 0.0f;
  public float droneFmFratio = 1.0f;
  public float dronePitchRange = 6.0f;
  public float jzChordOffset = 0.0f;
  public float monoMelChance = 60.0f;

  // internal state
  private Hv_musicObject_Context _context;

  public bool IsInstantiated() {
    return (_context != null);
  }

  public void RegisterSendHook() {
    _context.RegisterSendHook();
  }
  
  // see Hv_musicObject_AudioLib.Event for definitions
  public void SendEvent(Hv_musicObject_AudioLib.Event e) {
    if (IsInstantiated()) _context.SendBangToReceiver((uint) e);
  }
  
  // see Hv_musicObject_AudioLib.Parameter for definitions
  public float GetFloatParameter(Hv_musicObject_AudioLib.Parameter param) {
    switch (param) {
      case Parameter.Bpm: return BPM;
      case Parameter.Dronebinphase: return droneBinPhase;
      case Parameter.Dronechance: return droneChance;
      case Parameter.Dronefmamount: return droneFmAmount;
      case Parameter.Dronefmfratio: return droneFmFratio;
      case Parameter.Dronepitchrange: return dronePitchRange;
      case Parameter.Jzchordoffset: return jzChordOffset;
      case Parameter.Monomelchance: return monoMelChance;
      default: return 0.0f;
    }
  }

  public void SetFloatParameter(Hv_musicObject_AudioLib.Parameter param, float x) {
    switch (param) {
      case Parameter.Bpm: {
        x = Mathf.Clamp(x, 20.0f, 200.0f);
        BPM = x;
        break;
      }
      case Parameter.Dronebinphase: {
        x = Mathf.Clamp(x, 0.0f, 20.0f);
        droneBinPhase = x;
        break;
      }
      case Parameter.Dronechance: {
        x = Mathf.Clamp(x, 0.0f, 100.0f);
        droneChance = x;
        break;
      }
      case Parameter.Dronefmamount: {
        x = Mathf.Clamp(x, 0.0f, 2000.0f);
        droneFmAmount = x;
        break;
      }
      case Parameter.Dronefmfratio: {
        x = Mathf.Clamp(x, 0.1f, 4.0f);
        droneFmFratio = x;
        break;
      }
      case Parameter.Dronepitchrange: {
        x = Mathf.Clamp(x, 2.0f, 24.0f);
        dronePitchRange = x;
        break;
      }
      case Parameter.Jzchordoffset: {
        x = Mathf.Clamp(x, 0.0f, 48.0f);
        jzChordOffset = x;
        break;
      }
      case Parameter.Monomelchance: {
        x = Mathf.Clamp(x, 0.0f, 100.0f);
        monoMelChance = x;
        break;
      }
      default: return;
    }
    if (IsInstantiated()) _context.SendFloatToReceiver((uint) param, x);
  }
  
  public void FillTableWithMonoAudioClip(string tableName, AudioClip clip) {
    if (clip.channels > 1) {
      Debug.LogWarning("Hv_musicObject_AudioLib: Only loading first channel of '" +
          clip.name + "' into table '" +
          tableName + "'. Multi-channel files are not supported.");
    }
    float[] buffer = new float[clip.samples]; // copy only the 1st channel
    clip.GetData(buffer, 0);
    _context.FillTableWithFloatBuffer(tableName, buffer);
  }

  public void FillTableWithFloatBuffer(string tableName, float[] buffer) {
    _context.FillTableWithFloatBuffer(tableName, buffer);
  }

  private void Awake() {
    _context = new Hv_musicObject_Context((double) AudioSettings.outputSampleRate);
  }
  
  private void Start() {
    _context.SendFloatToReceiver((uint) Parameter.Bpm, BPM);
    _context.SendFloatToReceiver((uint) Parameter.Dronebinphase, droneBinPhase);
    _context.SendFloatToReceiver((uint) Parameter.Dronechance, droneChance);
    _context.SendFloatToReceiver((uint) Parameter.Dronefmamount, droneFmAmount);
    _context.SendFloatToReceiver((uint) Parameter.Dronefmfratio, droneFmFratio);
    _context.SendFloatToReceiver((uint) Parameter.Dronepitchrange, dronePitchRange);
    _context.SendFloatToReceiver((uint) Parameter.Jzchordoffset, jzChordOffset);
    _context.SendFloatToReceiver((uint) Parameter.Monomelchance, monoMelChance);
  }
  
  private void Update() {
    // retreive sent messages
    if (_context.IsSendHookRegistered()) {
      Hv_musicObject_AudioLib.FloatMessage tempMessage;
      while ((tempMessage = _context.msgQueue.GetNextMessage()) != null) {
        FloatReceivedCallback(tempMessage);
      }
    }
  }

  private void OnAudioFilterRead(float[] buffer, int numChannels) {
    Assert.AreEqual(numChannels, _context.GetNumOutputChannels()); // invalid channel configuration
    _context.Process(buffer, buffer.Length / numChannels); // process dsp
  }
}

class Hv_musicObject_Context {

#if UNITY_IOS && !UNITY_EDITOR
  private const string _dllName = "__Internal";
#else
  private const string _dllName = "Hv_musicObject_AudioLib";
#endif

  // Thread-safe message queue
  public class SendMessageQueue {
    private readonly object _msgQueueSync = new object();
    private readonly Queue<Hv_musicObject_AudioLib.FloatMessage> _msgQueue = new Queue<Hv_musicObject_AudioLib.FloatMessage>();

    public Hv_musicObject_AudioLib.FloatMessage GetNextMessage() {
      lock (_msgQueueSync) {
        return (_msgQueue.Count != 0) ? _msgQueue.Dequeue() : null;
      }
    }

    public void AddMessage(string receiverName, float value) {
      Hv_musicObject_AudioLib.FloatMessage msg = new Hv_musicObject_AudioLib.FloatMessage(receiverName, value);
      lock (_msgQueueSync) {
        _msgQueue.Enqueue(msg);
      }
    }
  }

  public readonly SendMessageQueue msgQueue = new SendMessageQueue();
  private readonly GCHandle gch;
  private readonly IntPtr _context; // handle into unmanaged memory
  private SendHook _sendHook = null;

  [DllImport (_dllName)]
  private static extern IntPtr hv_musicObject_new_with_options(double sampleRate, int poolKb, int inQueueKb, int outQueueKb);

  [DllImport (_dllName)]
  private static extern int hv_processInlineInterleaved(IntPtr ctx,
      [In] float[] inBuffer, [Out] float[] outBuffer, int numSamples);

  [DllImport (_dllName)]
  private static extern void hv_delete(IntPtr ctx);

  [DllImport (_dllName)]
  private static extern double hv_getSampleRate(IntPtr ctx);

  [DllImport (_dllName)]
  private static extern int hv_getNumInputChannels(IntPtr ctx);

  [DllImport (_dllName)]
  private static extern int hv_getNumOutputChannels(IntPtr ctx);

  [DllImport (_dllName)]
  private static extern void hv_setSendHook(IntPtr ctx, SendHook sendHook);

  [DllImport (_dllName)]
  private static extern void hv_setPrintHook(IntPtr ctx, PrintHook printHook);

  [DllImport (_dllName)]
  private static extern int hv_setUserData(IntPtr ctx, IntPtr userData);

  [DllImport (_dllName)]
  private static extern IntPtr hv_getUserData(IntPtr ctx);

  [DllImport (_dllName)]
  private static extern void hv_sendBangToReceiver(IntPtr ctx, uint receiverHash);

  [DllImport (_dllName)]
  private static extern void hv_sendFloatToReceiver(IntPtr ctx, uint receiverHash, float x);

  [DllImport (_dllName)]
  private static extern uint hv_msg_getTimestamp(IntPtr message);

  [DllImport (_dllName)]
  private static extern bool hv_msg_hasFormat(IntPtr message, string format);

  [DllImport (_dllName)]
  private static extern float hv_msg_getFloat(IntPtr message, int index);

  [DllImport (_dllName)]
  private static extern bool hv_table_setLength(IntPtr ctx, uint tableHash, uint newSampleLength);

  [DllImport (_dllName)]
  private static extern IntPtr hv_table_getBuffer(IntPtr ctx, uint tableHash);

  [DllImport (_dllName)]
  private static extern float hv_samplesToMilliseconds(IntPtr ctx, uint numSamples);

  [DllImport (_dllName)]
  private static extern uint hv_stringToHash(string s);

  private delegate void PrintHook(IntPtr context, string printName, string str, IntPtr message);

  private delegate void SendHook(IntPtr context, string sendName, uint sendHash, IntPtr message);

  public Hv_musicObject_Context(double sampleRate, int poolKb=10, int inQueueKb=2, int outQueueKb=2) {
    gch = GCHandle.Alloc(msgQueue);
    _context = hv_musicObject_new_with_options(sampleRate, poolKb, inQueueKb, outQueueKb);
    hv_setPrintHook(_context, new PrintHook(OnPrint));
    hv_setUserData(_context, GCHandle.ToIntPtr(gch));
  }

  ~Hv_musicObject_Context() {
    hv_delete(_context);
    GC.KeepAlive(_context);
    GC.KeepAlive(_sendHook);
    gch.Free();
  }

  public void RegisterSendHook() {
    // Note: send hook functionality only applies to messages containing a single float value
    if (_sendHook == null) {
      _sendHook = new SendHook(OnMessageSent);
      hv_setSendHook(_context, _sendHook);
    }
  }

  public bool IsSendHookRegistered() {
    return (_sendHook != null);
  }

  public double GetSampleRate() {
    return hv_getSampleRate(_context);
  }

  public int GetNumInputChannels() {
    return hv_getNumInputChannels(_context);
  }

  public int GetNumOutputChannels() {
    return hv_getNumOutputChannels(_context);
  }

  public void SendBangToReceiver(uint receiverHash) {
    hv_sendBangToReceiver(_context, receiverHash);
  }

  public void SendFloatToReceiver(uint receiverHash, float x) {
    hv_sendFloatToReceiver(_context, receiverHash, x);
  }

  public void FillTableWithFloatBuffer(string tableName, float[] buffer) {
    uint tableHash = hv_stringToHash(tableName);
    if (hv_table_getBuffer(_context, tableHash) != IntPtr.Zero) {
      hv_table_setLength(_context, tableHash, (uint) buffer.Length);
      Marshal.Copy(buffer, 0, hv_table_getBuffer(_context, tableHash), buffer.Length);
    } else {
      Debug.Log(string.Format("Table '{0}' doesn't exist in the patch context.", tableName));
    }
  }

  public uint StringToHash(string s) {
    return hv_stringToHash(s);
  }

  public int Process(float[] buffer, int numFrames) {
    return hv_processInlineInterleaved(_context, buffer, buffer, numFrames);
  }

  [MonoPInvokeCallback(typeof(PrintHook))]
  private static void OnPrint(IntPtr context, string printName, string str, IntPtr message) {
    float timeInSecs = hv_samplesToMilliseconds(context, hv_msg_getTimestamp(message)) / 1000.0f;
    Debug.Log(string.Format("{0} [{1:0.000}]: {2}", printName, timeInSecs, str));
  }

  [MonoPInvokeCallback(typeof(SendHook))]
  private static void OnMessageSent(IntPtr context, string sendName, uint sendHash, IntPtr message) {
    if (hv_msg_hasFormat(message, "f")) {
      SendMessageQueue msgQueue = (SendMessageQueue) GCHandle.FromIntPtr(hv_getUserData(context)).Target;
      msgQueue.AddMessage(sendName, hv_msg_getFloat(message, 0));
    }
  }
}
