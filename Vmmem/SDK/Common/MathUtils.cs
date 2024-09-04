using System.Numerics;

namespace Vmmem.SDK.Common;

public static class MathUtils
{
    
    /// <summary>
    /// 월드 좌표를 스크린 좌표로 변환
    /// </summary>
    /// <param name="worldPos"> 월드상 위치 </param>
    /// <param name="worldMatrix"> 오브젝트의 월드 행렬 </param>
    /// <param name="viewMatrix">카메라 뷰 행렬</param>
    /// <param name="projectionMatrix">카메라 프로젝션 행렬</param>
    /// <param name="screenWidth">모니터 가로크기</param>
    /// <param name="screenHeight">모니터 세로크기</param>
    /// <returns></returns>
    public static Vector3 WorldToScreen(Vector3 worldPos, Matrix4x4 worldMatrix, Matrix4x4 viewMatrix, Matrix4x4 projectionMatrix, float screenWidth, float screenHeight)
    { 
        // 월드 -> 뷰
        Vector4 viewCoords = Vector4.Transform(new Vector4(worldPos, 1.0f), worldMatrix);
        viewCoords = Vector4.Transform(viewCoords, viewMatrix); 
        
        // 뷰 -> 클립
        Vector4 clipCoords = Vector4.Transform(viewCoords, projectionMatrix);

        // 클립 -> NDC (0~1로 정규화)
        Vector3 ndc = new Vector3(clipCoords.X, clipCoords.Y, clipCoords.Z) / clipCoords.W;

        // NDC -> 스크린 좌표계로 변환
        Vector3 screenPos = new Vector3(
            (ndc.X + 1.0f) * 0.5f * screenWidth,
            (1.0f - ndc.Y) * 0.5f * screenHeight,
            ndc.Z
        ); 
         
        return screenPos;
    }
}