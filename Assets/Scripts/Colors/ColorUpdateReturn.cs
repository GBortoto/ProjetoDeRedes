using System;

public class ColorUpdateReturn{
	private bool finished;
	private float colorComponent;

	public ColorUpdateReturn (){
		this.finished = false;
	}

	public bool isfinished(){
		return finished;
	}
	public void setfinished(bool finished){
		this.finished = finished;
	}
	public float getColorComponent(){
		return colorComponent;
	}
	public void setColorComponent(float colorComponent){
		this.colorComponent = colorComponent;
	}

}

