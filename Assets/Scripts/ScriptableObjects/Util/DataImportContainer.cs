using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.Util
{
    [System.Serializable]
    public class PendingReference
    {
        public ScriptableObject targetObject; // 연결을 받을 객체 (예: DLG_MAYOR_INTRO)
        public string fieldName;              // 연결할 필드 이름 (예: "choices")
        public List<string> requiredIds;      // 연결해야 할 ID 목록 (예: ["CHOICE_CONFIRM", ...])
        public bool isList;                   // 필드가 GameData 리스트인지 단일 GameData 참조인지 나타냅니다.

        public PendingReference(ScriptableObject target, string field, List<string> ids, bool isList)
        {
            targetObject = target;
            fieldName = field;
            requiredIds = ids;
            this.isList = isList;
        }
    }

// 기존 DataImportContainer 클래스를 수정하여 PendingReference 목록을 포함시킵니다.
    public class DataImportContainer : ScriptableObject
    {
        public List<ScriptableObject> importedObjects = new List<ScriptableObject>();
        public List<PendingReference> pendingReferences = new List<PendingReference>(); // 이 줄을 추가!
    }
}