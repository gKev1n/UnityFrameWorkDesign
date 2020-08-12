namespace QFramework
{
    public class AssetBundleSceneResCreator : IResCreator
    {
        public bool Match(ResSearchKeys resSearchKeys)
        {
            var assetData = ResKit.ResData.GetAssetData(resSearchKeys);

            if (assetData != null)
            {
                return assetData.AssetType == ResLoadType.ABScene;
            }

            return false;
        }

        public IRes Create(ResSearchKeys resSearchKeys)
        {
            return AssetBundleSceneRes.Allocate(resSearchKeys.AssetName);
        }
    }
}