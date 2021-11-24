using UnityEngine;
using System.Collections.Generic;

public class LinesDrawer : MonoBehaviour {

	internal static LinesDrawer Instance;

	public LayerMask cantDrawOverLayer;
	int cantDrawOverLayerIndex;
	
	internal GameObject LinePrefab;

	[Space ( 30f )]
	public float linePointsMinDistance;
	public float lineWidth;

	Line currentLine;

	Camera cam;

	internal bool IsMovingObject = false;


    private void Awake()
    {
        if (Instance == null)
        {
			Instance = this;
        }
        else
        {
			Destroy(gameObject);
        }
    }


    void Start ( ) {
		cam = Camera.main;
		cantDrawOverLayerIndex = LayerMask.NameToLayer ( "CantDrawOver" );
	}

	void Update ( ) {

		if ( Input.GetMouseButtonDown ( 0 ) && !IsMovingObject)
			BeginDraw ( );

		if ( currentLine != null )
			Draw ( );

		if ( Input.GetMouseButtonUp ( 0 ) && !IsMovingObject)
			EndDraw ( );
	}

	// Begin Draw ----------------------------------------------
	void BeginDraw ( ) {
		currentLine = Instantiate ( LinePrefab, this.transform ).GetComponent <Line> ( );

		//Set line properties
		currentLine.UsePhysics ( false );
		//currentLine.SetLineColor ( lineColor );
		currentLine.SetPointsMinDistance ( linePointsMinDistance );
		currentLine.SetLineWidth ( lineWidth );

	}
	// Draw ----------------------------------------------------
	void Draw ( ) {
		Vector2 mousePosition = cam.ScreenToWorldPoint ( Input.mousePosition );

		//Check if mousePos hits any collider with layer "CantDrawOver", if true cut the line by calling EndDraw( )
		RaycastHit2D hit = Physics2D.CircleCast ( mousePosition, lineWidth / 3f, Vector2.zero, 1f, cantDrawOverLayer );

		if ( hit )
			EndDraw ( );
		else
			currentLine.AddPoint ( mousePosition );
	}
	// End Draw ------------------------------------------------
	void EndDraw ( ) {
		if ( currentLine != null ) {
			if ( currentLine.pointsCount < 2 ) {
				//If line has one point
				Destroy ( currentLine.gameObject );
			} else {
				//Add the line to "CantDrawOver" layer
				//currentLine.gameObject.layer = cantDrawOverLayerIndex;

				//Activate Physics on the line
				currentLine.UsePhysics ( false );

				currentLine = null;
			}
		}
	}
}
