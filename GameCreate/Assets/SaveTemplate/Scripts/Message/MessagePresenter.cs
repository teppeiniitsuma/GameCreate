﻿/*View, ModelのController*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MessageView))]
public class MessagePresenter : MonoBehaviour
{
    [SerializeField] private float _messageSpeed = 0.2f;
    public float MessageSpeed { set { _messageSpeed = value; } }
    private MessageView _textView;
    private CommonParam.TextType _textType = CommonParam.TextType.MainText;

    private string _originalMessage = "";
    private string _dispMessage = "";
    private int _messageCount = 0;
    private float _timer = 0;
    private System.Action _callback = null;

    public void SetMessage(CommonParam.TextType textType, string message, System.Action callback = null)
    {
        _callback = callback;
        _textType = textType;
        _originalMessage = message;
        _dispMessage = "";
        _messageCount = 0;
        _timer = 0;
        StartCoroutine(MessageDisp());
    }
    void Start()
    {
        _textView = GetComponent<MessageView>();
    }

    IEnumerator MessageDisp()
    {
        while(_messageCount < _originalMessage.Length)
        {
            _timer += Time.deltaTime;
            if(_timer >= _messageSpeed)
            {
                _timer = 0;
                _messageCount++;
                _dispMessage = _originalMessage.Substring(0, _messageCount);
                _textView.SetMessage(_dispMessage);
            }
            yield return null;
        }
        if (_callback != null) _callback();
    }

}
