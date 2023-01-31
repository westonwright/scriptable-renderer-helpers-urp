using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public static class RenderPassHelper
{
    public static void CreateBufferIfInvalid(ref ComputeBuffer computeBuffer, int count, int stride)
    {
        if (computeBuffer == null || !computeBuffer.IsValid()) computeBuffer = new ComputeBuffer(count, stride);
    }

    public static void CreateBufferReplace(ref ComputeBuffer computeBuffer, int count, int stride)
    {
        computeBuffer?.Dispose();
        computeBuffer = new ComputeBuffer(count, stride);
    }

    public static Vector3Int GetKernelThredGroupVector(ComputeShader computeShader, int kernelIndex)
    {
        computeShader.GetKernelThreadGroupSizes(kernelIndex, out uint x, out uint y, out uint z);
        return new Vector3Int((int)x, (int)y, (int)z);
    }

    public static void SetComputeIntParamsVector(CommandBuffer cmd, ComputeShader computeShader, string name, Vector2 vector)
    {
        cmd.SetComputeIntParams(computeShader, name, new int[] { (int)vector.x, (int)vector.y });
    }
    
    public static void SetComputeIntParamsVector(CommandBuffer cmd, ComputeShader computeShader, string name, Vector3 vector)
    {
        cmd.SetComputeIntParams(computeShader, name, new int[] { (int)vector.x, (int)vector.y, (int)vector.z });
    }

    public static void SetComputeIntParamsVector(CommandBuffer cmd, ComputeShader computeShader, string name, Vector4 vector)
    {
        cmd.SetComputeIntParams(computeShader, name, new int[] { (int)vector.x, (int)vector.y, (int)vector.z, (int)vector.w });
    }
    
    public static void SetComputeFloatParamsVector(CommandBuffer cmd, ComputeShader computeShader, string name, Vector2 vector)
    {
        cmd.SetComputeFloatParams(computeShader, name, new float[] { vector.x, vector.y });
    }
    
    public static void SetComputeFloatParamsVector(CommandBuffer cmd, ComputeShader computeShader, string name, Vector3 vector)
    {
        cmd.SetComputeFloatParams(computeShader, name, new float[] { vector.x, vector.y, vector.z });
    }

    public static void SetComputeFloatParamsVector(CommandBuffer cmd, ComputeShader computeShader, string name, Vector4 vector)
    {
        cmd.SetComputeFloatParams(computeShader, name, new float[] { vector.x, vector.y, vector.z, vector.w });
    }

    public static void Lol(Vector3 v)
    {

    }
    public static void Lol2(Vector3Int v)
    {

    }

    public static void DispatchComputeAtSize(
        CommandBuffer cmd, 
        ComputeShader computeShader, 
        int kernelIndex,
        Vector3 groupSizes,
        float totalSize
        )
    {
        cmd.DispatchCompute(computeShader, kernelIndex,
            Mathf.CeilToInt(totalSize / groupSizes.x),
            1,
            1
            );
    }

    public static void DispatchComputeAtSize(
        CommandBuffer cmd, 
        ComputeShader computeShader, 
        int kernelIndex,
        Vector3 groupSizes,
        float totalSizeX,
        float totalSizeY
        )
    {
        cmd.DispatchCompute(computeShader, kernelIndex,
            Mathf.CeilToInt(totalSizeX / groupSizes.x),
            Mathf.CeilToInt(totalSizeY / groupSizes.y),
            1
            );
    }
    
    public static void DispatchComputeAtSize(
        CommandBuffer cmd, 
        ComputeShader computeShader, 
        int kernelIndex,
        Vector3 groupSizes,
        Vector2 totalSizes
        )
    {
        cmd.DispatchCompute(computeShader, kernelIndex,
            Mathf.CeilToInt(totalSizes.x / groupSizes.x),
            Mathf.CeilToInt(totalSizes.y / groupSizes.y),
            1
            );
    }

    public static void DispatchComputeAtSize(
        CommandBuffer cmd,
        ComputeShader computeShader,
        int kernelIndex,
        Vector3 groupSizes,
        float totalSizeX,
        float totalSizeY,
        float totalSizeZ
        )
    {
        cmd.DispatchCompute(computeShader, kernelIndex,
            Mathf.CeilToInt(totalSizeX / groupSizes.x),
            Mathf.CeilToInt(totalSizeY / groupSizes.y),
            Mathf.CeilToInt(totalSizeZ / groupSizes.z)
            );
    }

    public static void DispatchComputeAtSize(
        CommandBuffer cmd, 
        ComputeShader computeShader, 
        int kernelIndex,
        Vector3 groupSizes,
        Vector3 totalSizes
        )
    {
        cmd.DispatchCompute(computeShader, kernelIndex,
            Mathf.CeilToInt(totalSizes.x / groupSizes.x),
            Mathf.CeilToInt(totalSizes.y / groupSizes.y),
            Mathf.CeilToInt(totalSizes.z / groupSizes.z)
            );
    }
}
