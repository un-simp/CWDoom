using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Zorro.Recorder;
using FfmpegEncoder = On.Zorro.Recorder.FfmpegEncoder;
using Unity;
using UnityEngine;
using UnityEngine.Video;

namespace CWDoom.Hooks;

public class FFmpegHook
{
	internal static IEnumerator FfmpegEncoderOnRunFfmpeg(FfmpegEncoder.orig_RunFfmpeg orig, Zorro.Recorder.FfmpegEncoder self, string arguments, bool displaywindow)
	{
		
		
		GameObject display = GameObject.CreatePrimitive(PrimitiveType.Cube);
		MeshRenderer renderer = display.GetComponentInChildren<MeshRenderer>();
		display.name = "Display";
		display.transform.position = new Vector3((float) -21.5031, (float) 2.83913, (float) 16.0612);
		display.transform.rotation =  Quaternion.Euler(0,(float) 44.8001,0);
		display.transform.localScale = new Vector3((float) 2.9277, (float) 1.7157, (float) 0.1608);
		
		Shader unlitTextureShader = Resources.FindObjectsOfTypeAll<Shader>().First((shader) => shader.name == "Universal Render Pipeline/Unlit");
		VideoPlayer videoPlayer = display.AddComponent<VideoPlayer>();
		videoPlayer.url = "https://jack.polancz.uk/rickrool.mp4";
		Material videoMaterial = new Material(unlitTextureShader);
		videoPlayer.Play();
		videoMaterial.mainTexture = videoPlayer.texture;
		renderer.material = videoMaterial;
		
		return orig(self, arguments, displaywindow);
	}
}