using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public static class RendererFeatureHelper
{
    public static bool GetMaterial(Shader shader, ref Material material)
    {
        if(material != null)
        {
            return true;
        }

        if (shader == null)
        {
            Debug.LogError("Shader Invalid!");
            return false;
        }
        else
        {
            material = CoreUtils.CreateEngineMaterial(shader);
            return true;
        }
    }

    public static void DisposeMaterial(ref Material material)
    {
        if (material != null)
        {
            CoreUtils.Destroy(material);
            material = null;
        }
    }

    public static bool ValidUniversalPipeline(RenderPipelineAsset pipeline, bool opaque, bool depth)
    {
        UniversalRenderPipelineAsset universal = (UniversalRenderPipelineAsset)pipeline;
        if (universal == null)
        {
            Debug.LogError("Not using proper Universal Render Pipeline Asset, check project settings!");
            return false;
        }
        if (opaque)
        {
            if (!universal)
            {
                Debug.LogError("Camera Opaque Texture not enabled on Universal Render Pipeline Asset!", universal);
                return false;
            }
        }
        if (depth)
        {
            if (!universal)
            {
                Debug.LogError("Camera Depth Texture not enabled on Universal Render Pipeline Asset!", universal);
                return false;
            }
        }
        return true;
    }

    public static bool LoadShader(ref Shader shaderRefrence, string filePath, string fileName)
    {
        if (shaderRefrence != null) return true; // already loaded
                                                 
        shaderRefrence = Resources.Load<Shader>(filePath + fileName);
        if (shaderRefrence == null)
        {
            Debug.LogError("Missing Shader " + fileName + "! Package may be corrupted!");
            Debug.LogError("Please reimport Package");
            return false;
        }
        return true;
    }

    public static bool LoadComputeShader(ref ComputeShader computeReference, string filePath, string fileName)
    {
        if (computeReference != null) return true; // already loaded

        computeReference = Resources.Load<ComputeShader>(filePath + fileName);
        if (computeReference == null)
        {
            Debug.LogError("Missing Compute Shader " + fileName + "! Package may be corrupted!");
            Debug.LogError("Please reimport Package");
            return false;
        }

        return true;
    }

    public static bool CameraTypeMatches(CameraType desiredType, CameraType actualType)
    {
        if (((int)desiredType & (int)actualType) == 0) return false;
        return true;
    }
}
