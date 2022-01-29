using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// UnityEvent with bool argument
/// </summary>
public class UnityBoolEvent : UnityEvent<bool> { }
/// <summary>
/// UnityEvent with integer argument
/// </summary>
public class UnityIntEvent : UnityEvent<int> { }
/// <summary>
/// UnityEvent with Color argument
/// </summary>
public class UnityColorEvent : UnityEvent<Color> { }
/// <summary>
/// UnityEvent with float argument
/// </summary>
public class TimerUpdatedEvent : UnityEvent<float> { }

/// <summary>
/// UnityEvent with two integer arguments, used to broadcast changes to the score
/// </summary>
public class ScoreChangedEvent : UnityEvent<int, int> { }

/// <summary>
/// Static class holding all relevant game events
/// </summary>
public static class GameEvents
{
    /// <summary>
    /// Event that is fired when current gold amount changes
    /// </summary>
    public static UnityIntEvent OnGoldChanged { get; } = new UnityIntEvent();

}
