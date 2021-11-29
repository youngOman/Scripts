using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackableStatusManager : MonoBehaviour, ITrackableEventHandler
{
    public enum TurnStates
    {
        LOST = 0,
        TRACK = 1
    }
    public TurnStates Status { get { return this.status; } set { status = value; } } //判斷是Track還是Lost
    private TurnStates status;
    private TrackableBehaviour trackableBehaviour;
    public GameObject ImageTarget;
    void Start()
    {
        trackableBehaviour = ImageTarget.GetComponent<TrackableBehaviour>();
        if (trackableBehaviour)
        {
            trackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            status = TurnStates.TRACK;
        }
        else
        {
            status = TurnStates.LOST;
        }
    }
}
