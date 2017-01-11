using UnityEngine;

public class LightExportData
{
	private Light lg;
	private Transform t;
	
	public LightExportData (Transform t)
	{
		this.t = t;
		this.lg = t.gameObject.GetComponent<Light>();
	}
	
	public string Name {
		get { return NamesUtil.CleanLc (t.name); }
	}
	
	public string Type {
		get {
			if (lg.type == LightType.Directional)
				return "1";
			else if (lg.type == LightType.Point)
				return "2";
			else // Spotlight
				return "3";
			
		
		}
	}
	
	public bool IsDirectional {
		get { return lg.type == LightType.Directional; }
	}
	
	public Color Color {
		get { return lg.color; }
	}
	
	public bool IsSpot {
		get { return lg.type == LightType.Spot; }
	}
	
	public float Angle {
		get { return lg.spotAngle / 180.0f * Mathf.PI - FalloffAngle; }
	}
	
	public float Intensity {
		get { return lg.intensity; }
	}
	
	public float FalloffAngle {
		get { return Mathf.PI / 32.0f; }
	}
	
	public string[] Direction {
		get {
			//Vector3 p = t.TransformDirection (t.forward);
			Vector3 p = -t.forward;
			return new string[] { p.x.ToString (ExporterProps.LN), p.y.ToString (ExporterProps.LN), (-p.z).ToString (ExporterProps.LN) };
		}
	}
}


